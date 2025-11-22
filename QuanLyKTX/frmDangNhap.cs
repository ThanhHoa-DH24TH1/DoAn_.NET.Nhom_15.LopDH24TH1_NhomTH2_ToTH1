// Thêm 2 dòng using này vào đầu file
using QuanLyKTX.Services;
using QuanLyKTX.Models; // Cần thiết để biết lớp User/Student

namespace QuanLyKTX
{
    public partial class frmDangNhap : Form
    {
        // Khai báo 2 Service
        private UserService _userService;
        private StudentService _studentService;
        public frmDangNhap()
        {
            InitializeComponent();

            // Khởi tạo (new) các Service để tránh lỗi 'null'
            _userService = new UserService();
            _studentService = new StudentService();
        }

        /// <summary>
        /// Xử lý nút Đăng Nhập
        /// </summary>
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDN.Text.Trim();
            string password = txtMK.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập và Mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // ----- BƯỚC 1: THỬ ĐĂNG NHẬP VỚI TƯ CÁCH ADMIN -----
                User adminUser = _userService.CheckLogin(username, password);
                if (adminUser != null)
                {
                    // Đăng nhập Admin thành công
                    MessageBox.Show($"Đăng nhập thành công với tư cách Quản trị viên!\nChào mừng {adminUser.FullName}.", "Đăng Nhập Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở Form Quản Lý (truyền Role qua)
                    frmDashboard f = new frmDashboard(adminUser.Role);
                    f.Show();

                    this.Hide();
                    return;
                }


                // ----- BƯỚC 2: THỬ ĐĂNG NHẬP VỚI TƯ CÁCH SINH VIÊN -----
                // (Chỉ chạy nếu Bước 1 thất bại)
                Student studentUser = _studentService.LoginAsStudent(username, password);
                if (studentUser != null)
                {
                    // Đăng nhập Sinh viên thành công
                    MessageBox.Show($"Đăng nhập thành công!\nChào mừng sinh viên {studentUser.FullName}.", "Đăng Nhập Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở Form Thông Tin Sinh Viên (truyền Mã SV qua)
                    frmThongTinSinhVien f = new frmThongTinSinhVien(studentUser.StudentCode);
                    f.Show();
                    this.Hide(); // Ẩn form đăng nhập
                    return; // Dừng hàm tại đây
                }

                // ----- BƯỚC 3: ĐĂNG NHẬP THẤT BẠI -----
                // (Chỉ chạy nếu cả 2 bước trên thất bại)
                MessageBox.Show("Tên đăng nhập hoặc Mật khẩu không chính xác.", "Đăng Nhập Thất Bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình đăng nhập: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý nút Thoát
        /// </summary>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Đảm bảo tắt toàn bộ ứng dụng
            Application.Exit();
        }

        /// <summary>
        /// (Tùy chọn) Xử lý nhấn Enter trong ô Mật khẩu
        /// </summary>
        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Giả lập việc nhấn nút Đăng nhập
                btnDangNhap_Click(sender, e);
            }
        }
    }
}