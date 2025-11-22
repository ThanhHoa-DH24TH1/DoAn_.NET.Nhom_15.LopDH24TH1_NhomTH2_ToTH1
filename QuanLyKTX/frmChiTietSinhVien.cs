// Thêm các using này vào đầu file
using QuanLyKTX.Services;
using QuanLyKTX.Models;
using System.Data;

namespace QuanLyKTX
{
    // Giả sử tên các control của bạn là:
    // txtMSSV, txtHoTen, dtpNgaySinh, rbNam, rbNu, txtCMND, txtSDT, txtEmail, txtDiaChi, txtKhoa, txtChuyenNganh, txtLop
    // cmbPhong (ComboBox Phòng)
    // btnLuu, btnHuy
    public partial class frmChiTietSinhVien : Form
    {
        private int? _studentId; // Dùng để biết đang Thêm (null) hay Sửa (có ID)
        private StudentService _studentService;
        private RoomService _roomService;

        public frmChiTietSinhVien(int? studentId)
        {
            InitializeComponent();
            _studentId = studentId;
            _studentService = new StudentService();
            _roomService = new RoomService();
        }

        private void frmChiTietSinhVien_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBoxes();

                if (_studentId.HasValue)
                {
                    // Chế độ Sửa: Tải thông tin
                    lbTen.AccessibilityObject.Name = "Cập Nhật Thông Tin Sinh Viên";    
                    this.Text = "Cập Nhật Thông Tin Sinh Viên";
                    LoadStudentData();
                }
                else
                {
                    // Chế độ Thêm
                    lbTen.AccessibilityObject.Name = "Thêm Sinh Viên Mới";
                    this.Text = "Thêm Sinh Viên Mới";
                    // Tùy chọn: Set 1 phòng trống mặc định
                    if (cbPhong.Items.Count > 0)
                        cbPhong.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải ComboBox Phòng
        /// </summary>
        private void LoadComboBoxes()
        {
            // =======================================================
            // == ĐÂY LÀ DÒNG ĐÃ ĐƯỢC SỬA LỖI ==
            // == GetAvailableRooms -> GetAvailableRoomsForContract ==
            // =======================================================
            var rooms = _roomService.GetAvailableRoomsForContract();
            // =======================================================
            // == KẾT THÚC PHẦN SỬA LỖI ==
            // =======================================================

            // Thêm một lựa chọn "Không có phòng" (cho SV mới/chưa đăng ký)
            var roomList = rooms.Select(r => new { r.RoomId, Display = $"{r.RoomNumber} (Còn: {r.Capacity - r.CurrentOccupancy})" })
                                .ToList();

            roomList.Insert(0, new { RoomId = 0, Display = "[Chưa Chọn Phòng]" });

            cbPhong.DataSource = roomList;
            cbPhong.DisplayMember = "Display";
            cbPhong.ValueMember = "RoomId";
        }

        /// <summary>
        /// Tải thông tin SV lên form (Chế độ Sửa)
        /// </summary>
        private void LoadStudentData()
        {
            try
            {
                var student = _studentService.GetStudentById(_studentId.Value);
                if (student == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Tải thông tin cơ bản
                txtMSSV.Text = student.StudentCode;
                txtHoTen.Text = student.FullName;
                dtpNgaySinh.Value = student.DateOfBirth.ToDateTime(TimeOnly.MinValue);
                if (student.Gender == "Nam")
                    rdbNam.Checked = true;
                else
                    rdbNu.Checked = true;
                txtCCCD.Text = student.Idcard;
                txtSDT.Text = student.PhoneNumber;
                txtEmail.Text = student.Email;
                txtDiaChi.Text = student.Address;
                txtKhoa.Text = student.Faculty;
                txtChuyenNganh.Text = student.Major;
                txtLop.Text = student.Class;
                txtMSSV.ReadOnly = true; // Không cho sửa MSSV

                // Tải thông tin phòng
                var contract = _studentService.GetActiveContractByStudentCode(student.StudentCode);
                if (contract != null)
                {
                    cbPhong.SelectedValue = contract.RoomId;
                }
                else
                {
                    cbPhong.SelectedValue = 0; // [Chưa Chọn Phòng]
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nút Hủy
        /// </summary>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Nút Lưu (Thêm/Sửa)
        /// </summary>
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu (Validation)
            if (string.IsNullOrWhiteSpace(txtMSSV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtCCCD.Text) ||
                string.IsNullOrWhiteSpace(txtKhoa.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ các trường có dấu (*).", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Tạo đối tượng Student từ Form
                var student = new Student
                {
                    StudentCode = txtMSSV.Text.Trim(),
                    FullName = txtHoTen.Text.Trim(),
                    DateOfBirth = DateOnly.FromDateTime(dtpNgaySinh.Value),
                    Gender = rdbNam.Checked ? "Nam" : "Nữ",
                    Idcard = txtCCCD.Text.Trim(),
                    PhoneNumber = txtSDT.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Address = txtDiaChi.Text.Trim(),
                    Faculty = txtKhoa.Text.Trim(),
                    Major = txtChuyenNganh.Text.Trim(),
                    Class = txtLop.Text.Trim()
                };

                // Lấy ID phòng đã chọn (0 = không chọn)
                int selectedRoomId = (int)cbPhong.SelectedValue;

                // 3. Gọi Service
                if (_studentId.HasValue)
                {
                    // Chế độ Sửa
                    student.StudentId = _studentId.Value;
                    _studentService.UpdateStudent(student, selectedRoomId);
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Chế độ Thêm
                    _studentService.AddStudent(student, selectedRoomId);
                    MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 4. Đóng form và báo thành công
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Bắt lỗi (ví dụ trùng MSSV)
                MessageBox.Show("Lưu thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}