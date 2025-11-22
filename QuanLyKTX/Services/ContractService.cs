using Microsoft.EntityFrameworkCore;
using QuanLyKTX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyKTX.Services
{
    // Lớp ViewModel để hiển thị trên DataGridView
    public class ContractViewModel
    {
        public int ContractId { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public string RoomNumber { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public decimal MonthlyFee { get; set; }
        public string Status { get; set; }
    }

    public class ContractService
    {
        private readonly DormitoryDBContext _context;

        public ContractService()
        {
            _context = new DormitoryDBContext();
        }

        /// <summary>
        /// Lấy danh sách hợp đồng (để join)
        /// </summary>
        private IQueryable<ContractViewModel> GetContractsQuery()
        {
            return from c in _context.Contracts
                   join s in _context.Students on c.StudentId equals s.StudentId
                   join r in _context.Rooms on c.RoomId equals r.RoomId
                   select new ContractViewModel
                   {
                       ContractId = c.ContractId,
                       StudentCode = s.StudentCode,
                       StudentName = s.FullName,
                       RoomNumber = r.RoomNumber,
                       StartDate = c.StartDate,
                       EndDate = c.EndDate,
                       MonthlyFee = c.MonthlyFee,
                       Status = c.Status
                   };
        }

        /// <summary>
        /// Lấy Hợp đồng cho DataGridView (có lọc)
        /// </summary>
        public List<ContractViewModel> GetContracts(string keyword, string status)
        {
            var query = GetContractsQuery();

            // Lọc theo từ khóa (Mã SV hoặc Tên SV)
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(c => c.StudentCode.Contains(keyword) || c.StudentName.Contains(keyword));
            }

            // Lọc theo trạng thái
            if (!string.IsNullOrEmpty(status) && status != "Tất cả")
            {
                query = query.Where(c => c.Status == status);
            }

            return query.OrderByDescending(c => c.StartDate).ToList();
        }

        /// <summary>
        // Lấy danh sách trạng thái cho ComboBox
        /// </summary>
        public List<string> GetStatusList()
        {
            var statuses = _context.Contracts
                .Select(c => c.Status)
                .Distinct()
                .ToList();

            statuses.Insert(0, "Tất cả");
            return statuses;
        }

        /// <summary>
        /// Thanh lý hợp đồng (Chuyển trạng thái)
        /// </summary>
        public bool TerminateContract(int contractId)
        {
            var contract = _context.Contracts.Find(contractId);
            if (contract == null) return false;

            // Nếu HĐ đã hết hạn/thanh lý thì thôi
            if (contract.Status != "Đang hiệu lực") return false;

            contract.Status = "Đã thanh lý";

            // Đồng thời, giảm số lượng sinh viên trong phòng
            var room = _context.Rooms.Find(contract.RoomId);
            if (room != null)
            {
                room.CurrentOccupancy -= 1;
                if (room.CurrentOccupancy < 0) room.CurrentOccupancy = 0; // Đảm bảo không âm

                // Cập nhật trạng thái phòng
                if (room.CurrentOccupancy == 0)
                    room.Status = "Trống";
                else if (room.CurrentOccupancy < room.Capacity)
                    room.Status = "Còn chỗ";

                _context.Rooms.Update(room);
            }

            _context.Contracts.Update(contract);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Tạo hợp đồng mới
        /// </summary>
        public string CreateContract(int studentId, int roomId, DateOnly startDate, DateOnly endDate, decimal deposit)
        {
            // 1. Kiểm tra sinh viên đã có HĐ chưa
            bool hasContract = _context.Contracts.Any(c => c.StudentId == studentId && c.Status == "Đang hiệu lực");
            if (hasContract)
            {
                return "Sinh viên này đã có hợp đồng, không thể tạo thêm.";
            }

            // 2. Lấy thông tin phòng
            var room = _context.Rooms.Find(roomId);
            if (room == null) return "Không tìm thấy phòng.";

            // 3. Kiểm tra phòng còn chỗ không
            if (room.Status == "Đầy")
            {
                return "Phòng đã đầy, không thể thêm.";
            }

            // 4. Tạo HĐ
            Contract newContract = new Contract
            {
                StudentId = studentId,
                RoomId = roomId,
                StartDate = startDate,
                EndDate = endDate,
                MonthlyFee = room.PricePerMonth, // Lấy giá từ phòng
                Deposit = deposit,
                Status = "Đang hiệu lực",
                SignedDate = DateOnly.FromDateTime(DateTime.Now)
            };
            _context.Contracts.Add(newContract);

            // 5. Cập nhật phòng (Tăng số người)
            room.CurrentOccupancy += 1;
            if (room.CurrentOccupancy == room.Capacity)
                room.Status = "Đầy";
            else
                room.Status = "Còn chỗ";

            _context.Rooms.Update(room);

            // 6. Lưu thay đổi
            _context.SaveChanges();
            return "Tạo hợp đồng thành công!";
        }

        // =======================================================
        // == HÀM MỚI (CHO frmGiaHanHopDong) ==
        // =======================================================
        /// <summary>
        /// Gia hạn hợp đồng
        /// </summary>
        public bool ExtendContract(int contractId, DateOnly newEndDate)
        {
            var contract = _context.Contracts.Find(contractId);
            if (contract == null) return false;

            // Kiểm tra logic: Ngày mới phải sau ngày cũ
            if (newEndDate <= contract.EndDate)
            {
                return false; // Hoặc ném một exception (tùy thiết kế)
            }

            // Cập nhật ngày kết thúc mới
            contract.EndDate = newEndDate;

            // Quan trọng: Nếu hợp đồng đã "Hết hạn" hoặc "Đã thanh lý",
            // hãy kích hoạt lại nó thành "Đang hiệu lực"
            if (contract.Status != "Đang hiệu lực")
            {
                contract.Status = "Đang hiệu lực";
            }

            _context.Contracts.Update(contract);
            _context.SaveChanges();
            return true;
        }
    }
}