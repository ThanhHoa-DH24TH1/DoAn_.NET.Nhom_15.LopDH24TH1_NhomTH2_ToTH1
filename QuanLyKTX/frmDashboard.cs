using QuanLyKTX.Helpers;
using QuanLyKTX.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKTX
{
    public partial class frmDashboard : Form
    {
        private StudentService _studentService;
        private RoomService _roomService;
        private InvoiceService _invoiceService;

        // Biến lưu quyền (có dấu gạch dưới)
        private string _userRole;

        // Constructor MẶC ĐỊNH (Không tham số - để tránh lỗi Designer)
        public frmDashboard()
        {
            InitializeComponent();
            this._userRole = "Admin"; // Mặc định nếu không truyền
            InitializeServices();
        }

        // Constructor CÓ THAM SỐ (Để frmDangNhap gọi)
        public frmDashboard(string role)
        {
            InitializeComponent();
            this._userRole = role;
            InitializeServices();
        }

        private void InitializeServices()
        {
            _studentService = new StudentService();
            _roomService = new RoomService();
            _invoiceService = new InvoiceService();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            LoadStatistics();
            ApplyPermissions();
        }

        private void LoadStatistics()
        {
            try
            {
                // 1. Tổng sinh viên
                if (lblSinhVien != null)
                    lblSinhVien.Text = _studentService.CountActiveStudents().ToString();

                // 2. Phòng trống
                if (lblPhongTrong != null)
                    lblPhongTrong.Text = _roomService.CountAvailableRooms().ToString();

                // 3. Hóa đơn chưa thanh toán
                if (lblChuaThanhToan != null)
                    lblChuaThanhToan.Text = _invoiceService.CountUnpaidInvoices().ToString();

                // 4. Doanh thu tháng này
                if (lblDoanhThuThang != null)
                {
                    string currentMonth = DateTime.Now.ToString("yyyy-MM");
                    decimal revenue = _invoiceService.GetMonthlyRevenue(currentMonth);
                    lblDoanhThuThang.Text = revenue.ToString("N0", new CultureInfo("vi-VN")) + " đ";
                }
            }
            catch (Exception ex)
            {
                // Không hiện lỗi để tránh phiền người dùng lúc mở app
                Console.WriteLine(ex.Message);
            }
        }

        private void ApplyPermissions()
        {
            if (_userRole != "Admin")
            {
                if (btnQLBaoCao != null) btnQLBaoCao.Enabled = false;
            }
        }

        // Hàm mở form con
        private void OpenForm(Form form)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == form.GetType())
                {
                    f.Activate();
                    return;
                }
            }
            form.Show();
        }

        private void btnQLSinhVien_Click(object sender, EventArgs e)
        {
            OpenForm(new frmQLSinhVien(_userRole));
        }

        private void btnQLPhong_Click(object sender, EventArgs e)
        {
            OpenForm(new frmQLPhong(_userRole));
        }

        private void btnQLThanhToan_Click(object sender, EventArgs e)
        {
            OpenForm(new frmQLThanhToan(_userRole));
        }

        private void btnQLHopDong_Click(object sender, EventArgs e)
        {
            OpenForm(new frmQLHopDong(_userRole));
        }

        private void btnQLBaoCao_Click(object sender, EventArgs e)
        {
            OpenForm(new frmBaoCao(_userRole));
        }
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            // Lấy thời gian hiện tại và định dạng
            // HH: giờ 24h, mm: phút, ss: giây
            // dd/MM/yyyy: ngày tháng năm
            string currentTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // Gán vào StatusLabel
            lblTime.Text = "Thời gian: " + currentTime;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;

            // Lấy tọa độ góc trên trái của nút so với màn hình
            Point screenPoint = pic.PointToScreen(Point.Empty);

            // Dịch chuyển điểm mục tiêu vào CHÍNH GIỮA nút (chiều ngang)
            screenPoint.X += pic.Width / 2;

            // Gọi Helper
            FormHelper.ToggleChatbot(screenPoint);
        }

        private void frmDashboard_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            LoadStatistics();
        }
    }
}
