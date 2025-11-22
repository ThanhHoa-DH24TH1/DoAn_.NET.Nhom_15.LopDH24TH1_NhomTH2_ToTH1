using Microsoft.EntityFrameworkCore;
using QuanLyKTX.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace QuanLyKTX.Services
{
    /// <summary>
    /// ViewModel để hiển thị trên DataGridView (Nối 3 bảng)
    /// </summary>
    public class InvoiceViewModel
    {
        public int InvoiceId { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public string RoomNumber { get; set; }
        public string BillingMonth { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public string Status { get; set; }
        public DateOnly? DueDate { get; set; }
        public DateOnly? PaymentDate { get; set; }
    }

    public class InvoiceService
    {
        private readonly DormitoryDBContext _context;

        public InvoiceService()
        {
            _context = new DormitoryDBContext();
        }

        /// <summary>
        /// Hàm Query gốc (internal) để các Service khác (như ReportService) có thể dùng
        /// </summary>
        internal IQueryable<InvoiceViewModel> GetInvoicesQuery()
        {
            var query = from i in _context.Invoices
                        join s in _context.Students on i.StudentId equals s.StudentId
                        join c in _context.Contracts on i.ContractId equals c.ContractId
                        join r in _context.Rooms on c.RoomId equals r.RoomId
                        select new InvoiceViewModel
                        {
                            InvoiceId = i.InvoiceId,
                            StudentCode = s.StudentCode,
                            StudentName = s.FullName,
                            RoomNumber = r.RoomNumber,
                            BillingMonth = i.BillingMonth,
                            TotalAmount = i.TotalAmount,
                            RemainingAmount = i.RemainingAmount,
                            Status = i.Status,
                            DueDate = i.DueDate,
                            PaymentDate = i.PaymentDate
                        };
            return query;
        }

        /// <summary>
        /// Lấy danh sách hóa đơn cho frmQLThanhToan (có lọc)
        /// </summary>
        public List<InvoiceViewModel> GetInvoices(string keyword, string billingMonth, string status)
        {
            var query = GetInvoicesQuery();

            // Lọc theo từ khóa (Mã SV hoặc Tên SV)
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(i => i.StudentCode.Contains(keyword) || i.StudentName.Contains(keyword));
            }

            // Lọc theo tháng
            if (!string.IsNullOrEmpty(billingMonth) && billingMonth != "Tất cả")
            {
                query = query.Where(i => i.BillingMonth == billingMonth);
            }

            // Lọc theo trạng thái
            if (!string.IsNullOrEmpty(status) && status != "Tất cả")
            {
                query = query.Where(i => i.Status == status);
            }

            return query.OrderByDescending(i => i.BillingMonth).ThenBy(i => i.Status).ToList();
        }

        /// <summary>
        /// Lấy danh sách hóa đơn CHỈ CỦA 1 SINH VIÊN (cho frmThongTinSinhVien)
        /// </summary>
        public List<InvoiceViewModel> GetInvoicesForStudent(string studentCode)
        {
            var query = GetInvoicesQuery();
            query = query.Where(i => i.StudentCode == studentCode)
                         .OrderByDescending(i => i.BillingMonth);
            
            return query.ToList();
        }

        /// <summary>
        /// Lấy danh sách các tháng đã có hóa đơn (cho ComboBox)
        /// </summary>
        public List<string> GetBillingMonths()
        {
            var months = _context.Invoices
                .Select(i => i.BillingMonth)
                .Distinct()
                .OrderByDescending(m => m)
                .ToList();
            months.Insert(0, "Tất cả");
            return months;
        }

        /// <summary>
        /// Xử lý thanh toán cho một hóa đơn
        /// </summary>
        public bool PayInvoice(int invoiceId)
        {
            var invoice = _context.Invoices.Find(invoiceId);
            if (invoice == null || invoice.Status == "Đã thanh toán")
            {
                return false;
            }

            invoice.Status = "Đã thanh toán";
            invoice.PaidAmount = invoice.TotalAmount;
            invoice.RemainingAmount = 0;
            invoice.PaymentDate = DateOnly.FromDateTime(DateTime.Now);

            _context.Invoices.Update(invoice);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Xóa hóa đơn (chỉ khi chưa thanh toán)
        /// </summary>
        public bool DeleteInvoice(int invoiceId)
        {
            var invoice = _context.Invoices.Find(invoiceId);
            if (invoice == null) return false;

            if (invoice.Status == "Đã thanh toán")
            {
                // Không cho xóa hóa đơn đã thanh toán
                return false;
            }

            _context.Invoices.Remove(invoice);
            _context.SaveChanges();
            return true;
        }


        /// <summary>
        /// TẠO HÓA ĐƠN HÀNG LOẠT (cho frmChiTietHoaDon)
        /// </summary>
        public string GenerateInvoices(string billingMonth, decimal electricityPrice, decimal waterPrice, decimal internetPrice, decimal serviceFee)
        {
            // 1. Kiểm tra tháng này đã tạo HĐ chưa
            bool alreadyGenerated = _context.Invoices.Any(i => i.BillingMonth == billingMonth);
            if (alreadyGenerated)
            {
                return $"Hóa đơn cho tháng {billingMonth} đã tồn tại. Không thể tạo trùng.";
            }

            // 2. Lấy danh sách HỢP ĐỒNG đang hiệu lực
            var activeContracts = _context.Contracts
                .Include(c => c.Room) // Lấy kèm thông tin phòng
                .Where(c => c.Status == "Đang hiệu lực")
                .ToList();

            if (!activeContracts.Any())
            {
                return "Không tìm thấy hợp đồng nào đang hiệu lực.";
            }

            var newInvoices = new List<Invoice>();
            foreach (var contract in activeContracts)
            {
                // 3. Tính toán các khoản phí
                // Giả sử các phí cố định (bạn có thể thay đổi logic này)
                // Ví dụ: chia đều tiền mạng, phí dịch vụ cho số người trong phòng
                int peopleInRoom = contract.Room?.CurrentOccupancy ?? 1;
                if (peopleInRoom == 0) peopleInRoom = 1; // Tránh chia cho 0

                decimal internetFeePerPerson = internetPrice / peopleInRoom;
                decimal serviceFeePerPerson = serviceFee / peopleInRoom;

                // Giả sử phí điện, nước là phí "giả định" cho 1 người (bạn sẽ cần sửa logic này nếu có đồng hồ)
                decimal electricityFee = electricityPrice; // Đây là đơn giá (ví dụ: 100kWh * đơn giá)
                decimal waterFee = waterPrice;             // Đây là đơn giá (ví dụ: 10m3 * đơn giá)

                // 4. Tính tổng
                decimal total = contract.MonthlyFee + electricityFee + waterFee + internetFeePerPerson + serviceFeePerPerson;

                // 5. Tạo đối tượng Hóa đơn
                Invoice newInvoice = new Invoice
                {
                    ContractId = contract.ContractId,
                    StudentId = contract.StudentId,
                    BillingMonth = billingMonth,
                    RoomFee = contract.MonthlyFee,
                    ElectricityFee = electricityFee,
                    WaterFee = waterFee,
                    InternetFee = internetFeePerPerson,
                    ServiceFee = serviceFeePerPerson,
                    TotalAmount = total,
                    PaidAmount = 0,
                    RemainingAmount = total,
                    Status = "Chưa thanh toán",
                    DueDate = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, 5).AddMonths(1), // Hạn là ngày 5 tháng sau
                    CreatedDate = DateTime.Now
                };
                newInvoices.Add(newInvoice);
            }

            // 6. Thêm đồng loạt vào CSDL
            _context.Invoices.AddRange(newInvoices);
            int count = _context.SaveChanges();

            return $"Tạo thành công {count} hóa đơn cho tháng {billingMonth}.";
        }
        public int CountUnpaidInvoices()
        {
            return _context.Invoices.Count(i => i.Status == "Chưa thanh toán");
        }

        /// <summary>
        /// Tính tổng doanh thu của tháng hiện tại (Dựa trên ngày tạo hoặc BillingMonth)
        /// </summary>
        public decimal GetMonthlyRevenue(string billingMonth)
        {
            // Lấy tổng tiền của các hóa đơn "Đã thanh toán" trong tháng đó
            return _context.Invoices
                .Where(i => i.BillingMonth == billingMonth && i.Status == "Đã thanh toán")
                .Sum(i => i.TotalAmount);
        }
    }
}