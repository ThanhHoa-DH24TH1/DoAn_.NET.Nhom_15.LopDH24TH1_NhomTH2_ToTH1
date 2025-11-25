using Microsoft.EntityFrameworkCore;
using QuanLyKTX.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

// Lớp ViewModel này chứa thông tin chi tiết Hợp đồng VÀ Phòng
// (Dùng cho frmThongTinSinhVien)
public class StudentContractInfoViewModel
{
    // Thông tin HĐ
    public int StudentId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public decimal Deposit { get; set; }
    public string Status { get; set; }

    // Thông tin Phòng (Join)
    public int RoomId { get; set; }
    public string RoomNumber { get; set; }
    public string Building { get; set; }
    public int Floor { get; set; }
    public string RoomType { get; set; }
    public decimal MonthlyFee { get; set; }
}


namespace QuanLyKTX.Services
{
    public class StudentService
    {
        private readonly DormitoryDBContext _context;

        public StudentService()
        {
            _context = new DormitoryDBContext();
        }

        /// <summary>
        /// Lấy danh sách Sinh viên cho frmQLSinhVien (có lọc)
        /// </summary>
        public List<Student> GetAllStudents(string keyword, string faculty)
        {
            var query = _context.Students.AsQueryable();

            // Lọc theo từ khóa
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(s => s.StudentCode.Contains(keyword) || s.FullName.Contains(keyword));
            }

            // Lọc theo khoa
            if (!string.IsNullOrEmpty(faculty) && faculty != "Tất cả")
            {
                query = query.Where(s => s.Faculty == faculty);
            }

            return query.OrderBy(s => s.FullName).ToList();
        }

        /// <summary>
        /// Lấy danh sách Khoa cho ComboBox
        /// </summary>
        public List<string> GetFaculties()
        {
            var faculties = _context.Students
                .Select(s => s.Faculty)
                .Distinct()
                .Where(f => f != null) // Bỏ qua các Khoa bị null
                .OrderBy(f => f)
                .ToList();

            faculties.Insert(0, "Tất cả"); // Thêm "Tất cả" vào đầu danh sách
            return faculties;
        }

        /// <summary>
        /// Lấy chi tiết 1 SV bằng ID (dùng cho form Sửa)
        /// </summary>
        public Student GetStudentById(int studentId)
        {
            return _context.Students.Find(studentId);
        }

        /// <summary>
        /// Lấy chi tiết 1 SV bằng Mã SV (dùng cho form Thông tin SV)
        /// </summary>
        public Student GetStudentByCode(string studentCode)
        {
            return _context.Students.FirstOrDefault(s => s.StudentCode == studentCode);
        }

        /// <summary>
        /// Lấy danh sách SV chưa có hợp đồng (cho frmTaoHopDong)
        /// </summary>
        public List<Student> GetStudentsWithoutContract()
        {
            // Lấy ID của các SV đang có HĐ hiệu lực
            var studentsWithContract = _context.Contracts
                .Where(c => c.Status == "Đang hiệu lực")
                .Select(c => c.StudentId);

            // Lấy các SV không nằm trong danh sách trên
            var studentsWithoutContract = _context.Students
                .Where(s => !studentsWithContract.Contains(s.StudentId))
                .OrderBy(s => s.FullName)
                .ToList();

            return studentsWithoutContract;
        }

        /// <summary>
        /// Lấy danh sách bạn cùng phòng (cho frmThongTinSinhVien)
        /// </summary>
        public List<string> GetRoommates(int roomId, int currentStudentId)
        {
            // Lấy ID của tất cả sinh viên trong phòng đó, trừ sinh viên hiện tại
            var roommateIds = _context.Contracts
                .Where(c => c.RoomId == roomId && c.StudentId != currentStudentId && c.Status == "Đang hiệu lực")
                .Select(c => c.StudentId)
                .ToList();

            if (!roommateIds.Any())
            {
                return new List<string>();
            }

            // Lấy tên của các sinh viên đó
            var roommateNames = _context.Students
                .Where(s => roommateIds.Contains(s.StudentId))
                .Select(s => s.FullName)
                .ToList();

            return roommateNames;
        }

        /// <summary>
        /// Lấy thông tin HĐ và Phòng đang ở của 1 SV bằng Mã SV (cho frmThongTinSinhVien)
        /// </summary>
        public StudentContractInfoViewModel GetActiveContractByStudentCode(string studentCode)
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentCode == studentCode);
            if (student == null) return null;

            // Join Hợp đồng và Phòng
            var contractInfo = (from c in _context.Contracts
                                join r in _context.Rooms on c.RoomId equals r.RoomId
                                where c.StudentId == student.StudentId && c.Status == "Đang hiệu lực"
                                select new StudentContractInfoViewModel
                                {
                                    StudentId = student.StudentId,
                                    StartDate = c.StartDate,
                                    EndDate = c.EndDate,
                                    Deposit = c.Deposit,
                                    Status = c.Status,
                                    RoomId = r.RoomId,
                                    RoomNumber = r.RoomNumber,
                                    Building = r.Building,
                                    Floor = r.Floor,
                                    RoomType = r.RoomType,
                                    MonthlyFee = r.PricePerMonth
                                }).FirstOrDefault();

            return contractInfo;
        }

        /// <summary>
        /// Thêm mới Sinh viên (và tự động tạo Hợp đồng nếu có chọn phòng)
        /// </summary>
        public void AddStudent(Student student, int? selectedRoomId)
        {
            _context.Students.Add(student);
            _context.SaveChanges(); // Lưu SV để lấy ID

            // Nếu Admin có chọn phòng, tự động tạo HĐ
            if (selectedRoomId.HasValue)
            {
                var room = _context.Rooms.Find(selectedRoomId.Value);
                if (room != null && room.Status != "Đầy")
                {
                    // Tự động tạo HĐ (ví dụ 1 năm, cọc 1 tháng)
                    Contract newContract = new Contract
                    {
                        StudentId = student.StudentId, // ID mới
                        RoomId = selectedRoomId.Value,
                        StartDate = DateOnly.FromDateTime(DateTime.Now),
                        EndDate = DateOnly.FromDateTime(DateTime.Now.AddYears(1)),
                        MonthlyFee = room.PricePerMonth,
                        Deposit = room.PricePerMonth,
                        Status = "Đang hiệu lực",
                        SignedDate = DateOnly.FromDateTime(DateTime.Now)
                    };
                    _context.Contracts.Add(newContract);

                    // Cập nhật phòng
                    room.CurrentOccupancy += 1;
                    if (room.CurrentOccupancy == room.Capacity) room.Status = "Đầy";
                    else room.Status = "Còn chỗ";
                    _context.Rooms.Update(room);

                    _context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Cập nhật Sinh viên (và Hợp đồng nếu có)
        /// </summary>
        public void UpdateStudent(Student student, int? selectedRoomId)
        {
            _context.Students.Update(student);

            // Xử lý logic đổi phòng (Nếu Admin chọn phòng khác)
            var currentContract = _context.Contracts.FirstOrDefault(c => c.StudentId == student.StudentId && c.Status == "Đang hiệu lực");

            // Case 1: SV đang có HĐ, và Admin chọn 1 phòng MỚI
            if (currentContract != null && selectedRoomId.HasValue && currentContract.RoomId != selectedRoomId.Value)
            {
                // Hủy phòng cũ
                var oldRoom = _context.Rooms.Find(currentContract.RoomId);
                if (oldRoom != null)
                {
                    oldRoom.CurrentOccupancy -= 1;
                    if (oldRoom.CurrentOccupancy < 0) oldRoom.CurrentOccupancy = 0;
                    oldRoom.Status = (oldRoom.CurrentOccupancy == 0) ? "Trống" : "Còn chỗ";
                    _context.Rooms.Update(oldRoom);
                }

                // Thêm vào phòng mới
                var newRoom = _context.Rooms.Find(selectedRoomId.Value);
                if (newRoom != null)
                {
                    newRoom.CurrentOccupancy += 1;
                    newRoom.Status = (newRoom.CurrentOccupancy == newRoom.Capacity) ? "Đầy" : "Còn chỗ";
                    _context.Rooms.Update(newRoom);

                    // Cập nhật HĐ
                    currentContract.RoomId = newRoom.RoomId;
                    currentContract.MonthlyFee = newRoom.PricePerMonth;
                    _context.Contracts.Update(currentContract);
                }
            }
            // Case 2: SV chưa có HĐ, và Admin chọn phòng
            else if (currentContract == null && selectedRoomId.HasValue)
            {
                // (Giống logic AddStudent)
                var room = _context.Rooms.Find(selectedRoomId.Value);
                if (room != null && room.Status != "Đầy")
                {
                    Contract newContract = new Contract { /* ... (Tạo HĐ mới) ... */ };
                    _context.Contracts.Add(newContract);
                    room.CurrentOccupancy += 1;
                    room.Status = (room.CurrentOccupancy == room.Capacity) ? "Đầy" : "Còn chỗ";
                    _context.Rooms.Update(room);
                }
            }

            _context.SaveChanges();
        }

        /// <summary>
        /// Xóa sinh viên (và tự động hủy HĐ nếu có)
        /// </summary>
        public bool DeleteStudent(int studentId)
        {
            var student = _context.Students.Find(studentId);
            if (student == null) return false;

            // 1. Tìm HĐ của SV
            var contract = _context.Contracts.FirstOrDefault(c => c.StudentId == studentId && c.Status == "Đang hiệu lực");
            if (contract != null)
            {
                // 2. Giảm số người trong phòng
                var room = _context.Rooms.Find(contract.RoomId);
                if (room != null)
                {
                    room.CurrentOccupancy -= 1;
                    if (room.CurrentOccupancy < 0) room.CurrentOccupancy = 0;
                    room.Status = (room.CurrentOccupancy == 0) ? "Trống" : "Còn chỗ";
                    _context.Rooms.Update(room);
                }

                // 3. Xóa HĐ
                _context.Contracts.Remove(contract);
            }

            // 4. Xóa SV
            _context.Students.Remove(student);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Đăng nhập với tư cách Sinh viên (cho frmDangNhap)
        /// </summary>
        public Student LoginAsStudent(string studentCode, string password)
        {
            // Mật khẩu cứng
            if (password != "12345") return null;

            // Tìm SV bằng Mã SV
            var student = _context.Students.FirstOrDefault(s => s.StudentCode == studentCode);

            return student; // Trả về student nếu tìm thấy, null nếu không
        }
        public int CountActiveStudents()
        {
            // Đếm những SV có trạng thái là "Đang ở" (hoặc đếm tất cả nếu bạn muốn)
            return _context.Students.Count(s => s.Status == "Đang ở");
        }
        public List<string> GetStudentNamesByRoomId(int roomId)
        {
            // Truy vấn từ bảng Contracts (Hợp đồng)
            // Lấy những HĐ có RoomId tương ứng và đang hiệu lực
            // Join sang bảng Students để lấy tên

            return _context.Contracts
                .Where(c => c.RoomId == roomId && c.Status == "Đang hiệu lực")
                .Include(c => c.Student) // Nối bảng Student
                .Select(c => c.Student.FullName) // Chỉ lấy cột Tên
                .ToList();
        }

    }
}