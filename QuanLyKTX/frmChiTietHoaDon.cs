// Thêm các using này vào đầu file
using QuanLyKTX.Services;
using System;
using System.Collections.Generic;
using System.Globalization; // Cần thiết cho việc Parse số
using System.Windows.Forms;

namespace QuanLyKTX
{
    // Giả sử tên các control của bạn là:
    // cmbThangNam, txtGiaDien, txtGiaNuoc, txtTienMang, txtPhiDichVu
    // btnTao, btnHuy
    public partial class frmChiTietHoaDon : Form
    {
        private readonly InvoiceService _invoiceService;
        private string _userRole;

        public frmChiTietHoaDon(string userRole)
        {
            InitializeComponent();
            _userRole = userRole;
            _invoiceService = new InvoiceService();
        }

        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            // Tải ComboBox Tháng/Năm
            // Lấy tháng năm hiện tại
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;

            List<string> months = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                // Thêm 6 tháng tới (bao gồm tháng này)
                DateTime nextMonth = DateTime.Now.AddMonths(i);
                months.Add(nextMonth.ToString("yyyy-MM")); // Format "2025-11"
            }
            cbThangNam.DataSource = months;

            // ĐẶT CÁC GIÁ TRỊ MẶC ĐỊNH
            txtDGDien.Text = "3000";
            txtDGNuoc.Text = "15000";
            txtTienMang.Text = "100000";
            txtPhiDichVu.Text = "50000";
        }

        // =======================================================
        // == HÀM ĐÃ SỬA LỖI "string" to "int" ==
        // =======================================================
        private void btnTao_Click(object sender, EventArgs e)
        {
            // 1. Lấy tháng/năm
            string billingMonth = cbThangNam.Text;

            // 2. Lấy CÁC CHUỖI (STRING) từ TextBox
            string strGiaDien = txtDGDien.Text;
            string strGiaNuoc = txtDGNuoc.Text;
            string strTienMang = txtTienMang.Text;
            string strPhiDichVu = txtPhiDichVu.Text;

            // 3. Validation
            if (string.IsNullOrEmpty(billingMonth))
            {
                MessageBox.Show("Vui lòng chọn tháng/năm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(strGiaDien) || string.IsNullOrEmpty(strGiaNuoc))
            {
                MessageBox.Show("Vui lòng nhập đơn giá điện và nước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. CHUYỂN ĐỔI (PARSE) SANG DECIMAL (Không phải INT)
            decimal giaDien, giaNuoc, tienMang, phiDichVu;

            try
            {
                // Dùng CultureInfo.InvariantCulture để đảm bảo parse dấu "."
                giaDien = decimal.Parse(strGiaDien, CultureInfo.InvariantCulture);
                giaNuoc = decimal.Parse(strGiaNuoc, CultureInfo.InvariantCulture);

                // Các phí này có thể bằng 0
                tienMang = string.IsNullOrEmpty(strTienMang) ? 0 : decimal.Parse(strTienMang, CultureInfo.InvariantCulture);
                phiDichVu = string.IsNullOrEmpty(strPhiDichVu) ? 0 : decimal.Parse(strPhiDichVu, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                MessageBox.Show("Đơn giá nhập không hợp lệ. Vui lòng chỉ nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 5. Gọi Service với đúng kiểu DECIMAL
            try
            {
                // Gọi hàm: (string, decimal, decimal, decimal, decimal)
                string result = _invoiceService.GenerateInvoices(billingMonth, giaDien, giaNuoc, tienMang, phiDichVu);

                MessageBox.Show(result, "Thông báo");

                // Nếu tạo thành công, báo cho form cha (frmQLThanhToan)
                if (result.StartsWith("Tạo thành công"))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}