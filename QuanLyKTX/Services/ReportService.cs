using QuanLyKTX.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyKTX.Services
{
    // Lớp tùy chỉnh để chứa dữ liệu cho biểu đồ (ĐÃ CÓ)
    public class RevenueByMonth
    {
        public string Month { get; set; }
        public decimal Revenue { get; set; }
    }

    public class ReportService
    {
        private readonly DormitoryDBContext _context;

        // =======================================================
        // == BỔ SUNG: Cần InvoiceService để lấy ViewModel ==
        private readonly InvoiceService _invoiceService;
        // =======================================================

        public ReportService()
        {
            _context = new DormitoryDBContext();

            // =======================================================
            // == BỔ SUNG: Khởi tạo InvoiceService ==
            _invoiceService = new InvoiceService();
            // =======================================================
        }

        /// <summary>
        /// Lấy dữ liệu TÓM TẮT cho BIỂU ĐỒ
        /// </summary>
        public List<RevenueByMonth> GetRevenueReport(string startMonth, string endMonth)
        {
            var paidInvoices = _context.Invoices
                .Where(i => i.Status == "Đã thanh toán");

            if (!string.IsNullOrEmpty(startMonth) && startMonth != "Tất cả")
            {
                paidInvoices = paidInvoices.Where(i => string.Compare(i.BillingMonth, startMonth) >= 0);
            }
            if (!string.IsNullOrEmpty(endMonth) && endMonth != "Tất cả")
            {
                paidInvoices = paidInvoices.Where(i => string.Compare(i.BillingMonth, endMonth) <= 0);
            }

            var reportData = paidInvoices
                .GroupBy(i => i.BillingMonth)
                .Select(group => new RevenueByMonth
                {
                    Month = group.Key,
                    Revenue = group.Sum(i => i.PaidAmount ?? 0)
                })
                .OrderBy(r => r.Month)
                .ToList();

            return reportData;
        }

        // =======================================================
        // == HÀM MỚI: Lấy dữ liệu CHI TIẾT cho DATAGRIDVIEW ==
        // =======================================================
        /// <summary>
        /// Lấy danh sách chi tiết các hóa đơn ĐÃ THANH TOÁN
        /// </summary>
        public List<InvoiceViewModel> GetRevenueDetailsReport(string startMonth, string endMonth)
        {
            // 1. Lấy IQueryable<InvoiceViewModel> từ InvoiceService
            //    Hàm này đã join Student, Room...
            var query = _invoiceService.GetInvoicesQuery();

            // 2. Chỉ lọc các hóa đơn "Đã thanh toán"
            query = query.Where(i => i.Status == "Đã thanh toán");

            // 3. Lọc theo thời gian
            if (!string.IsNullOrEmpty(startMonth) && startMonth != "Tất cả")
            {
                query = query.Where(i => string.Compare(i.BillingMonth, startMonth) >= 0);
            }
            if (!string.IsNullOrEmpty(endMonth) && endMonth != "Tất cả")
            {
                query = query.Where(i => string.Compare(i.BillingMonth, endMonth) <= 0);
            }

            // 4. Trả về danh sách chi tiết
            return query.OrderBy(i => i.BillingMonth).ThenBy(i => i.StudentName).ToList();
        }
    }
}