using Microsoft.EntityFrameworkCore;
using QuanLyKTX.Models;
using System.Data;

namespace QuanLyKTX.Services
{
    public class RoomService
    {
        private readonly DormitoryDBContext _context;

        public RoomService()
        {
            _context = new DormitoryDBContext();
        }

        /// <summary>
        /// Lấy tất cả phòng cho DataGridView (có lọc)
        /// </summary>
        public List<Room> GetAllRooms(string building, int? floor, string status)
        {
            var query = _context.Rooms.AsQueryable();

            // Lọc theo Tòa
            if (!string.IsNullOrEmpty(building) && building != "Tất cả")
            {
                query = query.Where(r => r.Building == building);
            }

            // Lọc theo Tầng
            if (floor.HasValue)
            {
                query = query.Where(r => r.Floor == floor.Value);
            }

            // Lọc theo Trạng thái
            if (!string.IsNullOrEmpty(status) && status != "Tất cả")
            {
                query = query.Where(r => r.Status == status);
            }

            return query.OrderBy(r => r.RoomNumber).ToList();
        }

        /// <summary>
        /// Lấy 1 phòng bằng ID
        /// </summary>
        public Room GetRoomById(int roomId)
        {
            return _context.Rooms.Find(roomId);
        }

        /// <summary>
        /// Thêm phòng mới
        /// </summary>
        public Boolean AddRoom(Room room)
        {
            // Kiểm tra trùng Số phòng
            if (_context.Rooms.Any(r => r.RoomNumber == room.RoomNumber))
            {
                throw new Exception("Số phòng này đã tồn tại.");
                return false;
            }
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return true;

        }

        /// <summary>
        /// Cập nhật thông tin phòng
        /// </summary>
        public void UpdateRoom(Room room)
        {
            // Kiểm tra trùng (trừ chính nó)
            if (_context.Rooms.Any(r => r.RoomNumber == room.RoomNumber && r.RoomId != room.RoomId))
            {
                throw new Exception("Số phòng này đã tồn tại.");
            }

            // Cập nhật thông tin cơ bản
            _context.Entry(room).State = EntityState.Modified;

            // Cập nhật Trạng thái phòng dựa trên Số lượng
            if (room.CurrentOccupancy == 0)
                room.Status = "Trống";
            else if (room.CurrentOccupancy >= room.Capacity)
                room.Status = "Đầy";
            else
                room.Status = "Còn chỗ";

            _context.SaveChanges();
        }

        /// <summary>
        /// Xóa phòng
        /// </summary>
        public void DeleteRoom(int roomId)
        {
            // Kiểm tra phòng có sinh viên không
            if (_context.Contracts.Any(c => c.RoomId == roomId && c.Status == "Đang hiệu lực"))
            {
                throw new Exception("Không thể xóa phòng đang có sinh viên ở.");
            }

            var room = _context.Rooms.Find(roomId);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }

        // =======================================================
        // == CÁC HÀM LẤY DANH SÁCH CHO COMBOBOX ==
        // =======================================================

        /// <summary>
        /// Lấy danh sách Tòa nhà (A, B...)
        /// </summary>
        public List<string> GetBuildingList()
        {
            var buildings = _context.Rooms
                .Select(r => r.Building)
                .Distinct()
                .OrderBy(b => b)
                .ToList();
            buildings.Insert(0, "Tất cả");
            return buildings;
        }

        /// <summary>
        /// Lấy danh sách Tầng (1, 2, 3...)
        /// </summary>
        public List<int?> GetFloorList()
        {
            var floors = _context.Rooms
               .Select(r => (int?)r.Floor)
               .Distinct()
               .OrderBy(f => f)
               .ToList();
            floors.Insert(0, null); // null = "Tất cả"
            return floors;
        }

        /// <summary>
        /// Lấy danh sách Trạng thái (Trống, Đầy...)
        /// </summary>
        public List<string> GetStatusList()
        {
            var statuses = _context.Rooms
               .Select(r => r.Status)
               .Distinct()
               .OrderBy(s => s)
               .ToList();
            statuses.Insert(0, "Tất cả");
            return statuses;
        }

        /// <summary>
        /// Lấy danh sách Loại Phòng cho ComboBox (HÀM MỚI ĐÃ THÊM)
        /// </summary>
        public List<string> GetRoomTypeList()
        {
            // Lấy các giá trị RoomType duy nhất từ CSDL
            var roomTypes = _context.Rooms
                .Select(r => r.RoomType)
                .Where(rt => rt != null) // Bỏ qua nếu có loại phòng là null
                .Distinct()
                .OrderBy(rt => rt)
                .ToList();

            return roomTypes;
        }


        /// <summary>
        /// Lấy các phòng còn trống (cho form Tạo Hợp Đồng)
        /// </summary>
        public List<Room> GetAvailableRoomsForContract()
        {
            return _context.Rooms
                .Where(r => r.Status == "Trống" || r.Status == "Còn chỗ")
                .OrderBy(r => r.RoomNumber)
                .ToList();
        }
        public int CountAvailableRooms()
        {
            return _context.Rooms.Count(r => r.Status == "Trống" || r.Status == "Còn chỗ");
        }
    }
}