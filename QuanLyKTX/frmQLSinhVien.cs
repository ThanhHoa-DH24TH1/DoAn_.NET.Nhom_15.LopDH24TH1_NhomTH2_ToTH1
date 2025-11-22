// Thêm các using này vào đầu file
using QuanLyKTX.Helpers;
using QuanLyKTX.Models;
using QuanLyKTX.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyKTX
{
    public partial class frmQLSinhVien : Form
    {
        // BIẾN NÀY GÂY LỖI NẾU KHÔNG ĐƯỢC KHỞI TẠO
        private StudentService _studentService;

        private string _userRole;

        public frmQLSinhVien(string userRole)
        {
            InitializeComponent();

            _studentService = new StudentService();

            this._userRole = userRole;
        }

        /// <summary>
        /// Sự kiện Form Load
        /// </summary>
        private void frmQLSinhVien_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadStudents();
            SetupDataGridView();
            ApplyPermissions();
        }

        /// <summary>
        /// Phân quyền (Ẩn/hiện nút theo vai trò)
        /// </summary>
        private void ApplyPermissions()
        {
            bool isAdmin = (_userRole == "Admin");
            btnThem.Visible = isAdmin;
            btnXoa.Visible = isAdmin;
            btnSua.Visible = isAdmin;
        }

        /// <summary>
        /// Tải dữ liệu cho ComboBox Khoa
        /// </summary>
        private void LoadComboBoxes()
        {
            try
            {
                var faculties = _studentService.GetFaculties();
                cbKhoa.DataSource = faculties;
                cbKhoa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách Khoa: {ex.Message}");
            }
        }

        /// <summary>
        /// Tải danh sách Sinh viên lên DataGridView
        /// </summary>
        private void LoadStudents()
        {
            try
            {
                string keyword = txtTimSV.Text.Trim();
                string faculty = cbKhoa.SelectedValue?.ToString() ?? "Tất cả";

                // Dòng này sẽ gây lỗi nếu _studentService là null
                var students = _studentService.GetAllStudents(keyword, faculty);

                dgvSinhVien.DataSource = students;
            }
            catch (Exception ex)
            {
                // ĐÂY LÀ LỖI BẠN THẤY:
                MessageBox.Show($"Không thể tải danh sách sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cài đặt hiển thị cho các cột
        /// </summary>
        private void SetupDataGridView()
        {
            var dgv = dgvSinhVien;
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = true; // Bật STT

            // Cột ẩn ID
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StudentId",
                DataPropertyName = "StudentId",
                Visible = false
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StudentCode",
                HeaderText = "Mã SV",
                DataPropertyName = "StudentCode",
                Width = 80
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                HeaderText = "Họ Tên",
                DataPropertyName = "FullName",
                Width = 150
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Gender",
                HeaderText = "Giới Tính",
                DataPropertyName = "Gender",
                Width = 80
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DateOfBirth",
                HeaderText = "Ngày Sinh",
                DataPropertyName = "DateOfBirth",
                Width = 100
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Faculty",
                HeaderText = "Khoa",
                DataPropertyName = "Faculty",
                Width = 120
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PhoneNumber",
                HeaderText = "SĐT",
                DataPropertyName = "PhoneNumber",
                Width = 100
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Class",
                HeaderText = "Lớp",
                DataPropertyName = "Class",
                Width = 100
            });

            // Gán sự kiện vẽ STT (nếu bạn đã copy hàm này)
            dgv.DataBindingComplete += dgv_DataBindingComplete;
        }

        // HÀM VẼ SỐ THỨ TỰ
        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;
            dgv.RowHeadersWidth = 55;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        // Nút Tìm
        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        // Nút Làm Mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimSV.Text = "";
            cbKhoa.SelectedIndex = 0;
            LoadStudents();
        }

        // Nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmChiTietSinhVien f = new frmChiTietSinhVien(null); // null = Chế độ Thêm
            if (f.ShowDialog() == DialogResult.OK)
            {
                // Tải lại Grid sau khi Thêm thành công
                LoadStudents();
            }
        }

        // Nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy StudentId từ cột ẩn
            int studentId = (int)dgvSinhVien.CurrentRow.Cells["StudentId"].Value;

            frmChiTietSinhVien f = new frmChiTietSinhVien(studentId); // studentId = Chế độ Sửa
            if (f.ShowDialog() == DialogResult.OK)
            {
                // Tải lại Grid sau khi Sửa thành công
                LoadStudents();
            }
        }

        // Nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int studentId = (int)dgvSinhVien.CurrentRow.Cells["StudentId"].Value;
            string studentName = dgvSinhVien.CurrentRow.Cells["FullName"].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc muốn xóa sinh viên này?\n\n{studentName} (ID: {studentId})\n\n(Việc này sẽ tự động hủy hợp đồng nếu có)", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // SỬA LỖI (bool):
                    bool success = _studentService.DeleteStudent(studentId);

                    if (success)
                    {
                        MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStudents(); // Tải lại
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại (Không tìm thấy sinh viên).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // Đóng Form (Quan trọng)
        private void frmQLSinhVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        // ===================================================================
        // CÁC HÀM XỬ LÝ CHO MENUSTRIP (ĐIỀU HƯỚNG)
        // ===================================================================

        /// <summary>
        /// Hàm chung để mở Form, kiểm tra trùng lặp
        /// </summary>
        private void OpenForm(Form formToOpen)
        {
            // Kiểm tra xem form đã mở chưa
            var existingForm = Application.OpenForms.OfType<Form>().FirstOrDefault(f => f.GetType() == formToOpen.GetType());

            if (existingForm != null)
            {
                existingForm.Activate(); // Đưa lên trên
            }
            else
            {
                formToOpen.Show(); // Mở form mới
            }
        }

        private void mnQuanLyPhong_Click(object sender, EventArgs e)
        {
            // Chúng ta cần truyền Role qua
            frmQLPhong f = new frmQLPhong(_userRole);
            OpenForm(f);
        }

        private void mnQLThanhToan_Click(object sender, EventArgs e)
        {
            // Chúng ta cần truyền Role qua
            frmQLThanhToan f = new frmQLThanhToan(_userRole);
            OpenForm(f);
        }

        private void mnQLBaoCao_Click(object sender, EventArgs e)
        {

            frmBaoCao f = new frmBaoCao(_userRole);
            OpenForm(f);
        }

        private void mnQLHopDong_Click(object sender, EventArgs e)
        {
            // (Giả sử bạn đã thêm nút Quản lý Hợp đồng)
            frmQLHopDong f = new frmQLHopDong(_userRole);
            OpenForm(f);
        }
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // Gọi 1 dòng duy nhất
            ExcelHelper.ExportToExcel(dgvSinhVien, "DanhSachSinhVien", "DS_SinhVien");
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
    }
}