// Thêm các using này vào đầu file
using QuanLyKTX.Models;
using QuanLyKTX.Services;
using System.Data;

namespace QuanLyKTX
{
    public partial class frmChiTietHopDong : Form
    {
        // Giả sử tên control
        // cmbStudent, cmbRoom, dtpStartDate, dtpEndDate, txtDeposit, btnLuu, btnHuy

        private ContractService _contractService;
        private StudentService _studentService;
        private RoomService _roomService;

        public frmChiTietHopDong()
        {
            InitializeComponent();
            _contractService = new ContractService();
            _studentService = new StudentService();
            _roomService = new RoomService();
        }

        private void frmChiTietHopDong_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadRooms();

            // Cài đặt mặc định
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(10); // HĐ 10 tháng
        }

        /// <summary>
        /// Tải DS Sinh viên CHƯA CÓ HỢP ĐỒNG
        /// </summary>
        private void LoadStudents()
        {
            try
            {
                // Gọi hàm mới (sẽ thêm ở File 4)
                var students = _studentService.GetStudentsWithoutContract();
                cmbStudent.DataSource = students;
                cmbStudent.DisplayMember = "FullName"; // Hiển thị tên
                cmbStudent.ValueMember = "StudentId"; // Lấy ID
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sinh viên: " + ex.Message);
            }
        }

        /// <summary>
        /// Tải DS Phòng CÒN CHỖ
        /// </summary>
        private void LoadRooms()
        {
            try
            {
                // Gọi hàm mới (sẽ thêm ở File 5)
                var rooms = _roomService.GetAvailableRoomsForContract();
                cmbRoom.DataSource = rooms;
                cmbRoom.DisplayMember = "RoomNumber"; // Hiển thị tên phòng
                cmbRoom.ValueMember = "RoomId"; // Lấy ID
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phòng: " + ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Validate
            if (cmbStudent.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên.", "Thiếu thông tin");
                return;
            }
            if (cmbRoom.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng.", "Thiếu thông tin");
                return;
            }
            if (!decimal.TryParse(txtDeposit.Text, out decimal deposit))
            {
                MessageBox.Show("Tiền đặt cọc không hợp lệ.", "Sai định dạng");
                return;
            }
            if (dtpEndDate.Value <= dtpStartDate.Value)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu.", "Lỗi logic");
                return;
            }

            // 2. Lấy giá trị
            int studentId = (int)cmbStudent.SelectedValue;
            int roomId = (int)cmbRoom.SelectedValue;
            DateOnly startDate = DateOnly.FromDateTime(dtpStartDate.Value);
            DateOnly endDate = DateOnly.FromDateTime(dtpEndDate.Value);

            // 3. Gọi Service
            try
            {
                string result = _contractService.CreateContract(studentId, roomId, startDate, endDate, deposit);
                MessageBox.Show(result, "Thông báo");

                if (result.Contains("thành công"))
                {
                    this.DialogResult = DialogResult.OK; // Đặt kết quả để form mẹ tải lại
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo hợp đồng: " + ex.Message, "Lỗi");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}