
using QuanLyKTX.Helpers;
using QuanLyKTX.Models;
using QuanLyKTX.Services;
using System; // Cần cho Exception
using System.Collections.Generic; // Cần cho List
using System.Data; // Cần cho ComboBox
using System.Linq; // Cần cho ComboBox
using System.Windows.Forms; // Cần cho MessageBox

namespace QuanLyKTX
{
    public partial class frmQLPhong : Form
    {
        private RoomService _roomService;
        private string _userRole; // Để phân quyền

        public frmQLPhong(string userRole)
        {
            InitializeComponent();
            _roomService = new RoomService();
            _userRole = userRole;
        }

        private void frmQLPhong_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadRooms(); // << LỖI ĐANG XẢY RA Ở ĐÂY
            SetupDataGridView();

        }


        private void LoadComboBoxes()
        {
            // Tải Tòa
            cbToa.DataSource = _roomService.GetBuildingList();

            // Tải Trạng thái
            cbTrangThai.DataSource = _roomService.GetStatusList();

            // Tải Tầng (phụ thuộc vào Tòa)
            LoadFloorComboBox();
        }

        private void LoadFloorComboBox()
        {
            string selectedBuilding = cbToa.SelectedItem?.ToString() ?? "Tất cả";
            cbTang.DataSource = _roomService.GetFloorList();
        }

        // Sự kiện khi thay đổi Tòa -> Tải lại Tầng
        private void cmbBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFloorComboBox();
        }

        private void LoadRooms()
        {
            // Lấy giá trị từ ComboBox
            string building = cbToa.SelectedItem?.ToString() ?? "Tất cả";
            int? floor = null;
            if (cbTang.SelectedItem?.ToString() != "Tất cả" && int.TryParse(cbTang.SelectedItem?.ToString(), out int f))
            {
                floor = f;
            }
            string status = cbTrangThai.SelectedItem?.ToString() ?? "Tất cả";

            try
            {
                // Truyền 3 tham số vào hàm GetAllRooms
                dgvPhong.DataSource = _roomService.GetAllRooms(building, floor, status);

                // Ẩn cột ID
                if (dgvPhong.Columns["RoomID"] != null)
                {
                    dgvPhong.Columns["RoomID"].Visible = false;
                    dgvPhong.Columns["RoomNumber"].HeaderText = "Số Phòng";
                    dgvPhong.Columns["Building"].HeaderText = "Tòa";
                    dgvPhong.Columns["Floor"].HeaderText = "Tầng";
                    dgvPhong.Columns["RoomType"].HeaderText = "Loại Phòng";
                    dgvPhong.Columns["Capacity"].HeaderText = "Sức Chứa";
                    dgvPhong.Columns["PricePerMonth"].HeaderText = "Giá Tháng";
                    dgvPhong.Columns["PricePerMonth"].DefaultCellStyle.Format = "N0"; // Định dạng số
                    dgvPhong.Columns["Status"].HeaderText = "Trạng Thái";
                    dgvPhong.Columns["Description"].HeaderText = "Ghi Chú";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách phòng: " + ex.Message, "Lỗi");
            }
        }

        private void SetupDataGridView()
        {
            dgvPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPhong.ReadOnly = true;
            dgvPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhong.MultiSelect = false;
        }

        // Nút "Làm Mới" (hoặc "Tìm Kiếm")
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRooms();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            // Mở form ở chế độ Thêm
            frmChiTietPhong f = new frmChiTietPhong(null);

            // Dùng ShowDialog() để form QLPhong bị "đứng" lại,
            // chờ form ChiTiet đóng
            if (f.ShowDialog() == DialogResult.OK)
            {
                // Nếu form ChiTiet báo OK (đã Lưu), tải lại Grid
                LoadRooms();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một phòng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy RoomID từ cột (giả sử tên cột là "RoomID")
            int roomId = (int)dgvPhong.CurrentRow.Cells["RoomID"].Value;

            // Mở form ở chế độ Sửa
            frmChiTietPhong f = new frmChiTietPhong(roomId);
            if (f.ShowDialog() == DialogResult.OK)
            {
                // Tải lại Grid nếu Sửa thành công
                LoadRooms();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một phòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int roomId = (int)dgvPhong.CurrentRow.Cells["RoomID"].Value;
            string roomNumber = dgvPhong.CurrentRow.Cells["RoomNumber"].Value.ToString();

            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa phòng '{roomNumber}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _roomService.DeleteRoom(roomId);
                    MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRooms(); // Tải lại Grid
                }
                catch (Exception ex)
                {
                    // Lỗi này sẽ xảy ra nếu phòng đang có sinh viên
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvRooms_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Double click để Sửa (nếu là Admin)
            if (_userRole == "Admin")
            {
                btnSua_Click(sender, e);
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadRooms();
        }
        private void mnQLBaoCao_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem form frmBaoCao đã mở chưa
            var existingForm = Application.OpenForms.OfType<frmBaoCao>().FirstOrDefault();

            if (existingForm != null)
            {
                // Nếu đã mở, đưa nó lên trên cùng
                existingForm.BringToFront();
            }
            else
            {
                // Nếu chưa mở, tạo mới và truyền quyền
                // (Form Báo Cáo có thể không cần quyền, tùy bạn)
                frmBaoCao f = new frmBaoCao(_userRole);
                f.Show();
            }


        }
        private void mnQuanLySinhVien_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem form frmQLSinhVien đã mở chưa
            var existingForm = Application.OpenForms.OfType<frmQLSinhVien>().FirstOrDefault();
            if (existingForm != null)
            {
                // Nếu đã mở, đưa nó lên trên cùng
                existingForm.BringToFront();
            }
            else
            {
                // Nếu chưa mở, tạo mới và truyền quyền
                frmQLSinhVien f = new frmQLSinhVien(_userRole);
                f.Show();
            }
        }
        private void mnQuanLyHopDong_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem form frmQLHopDong đã mở chưa
            var existingForm = Application.OpenForms.OfType<frmQLHopDong>().FirstOrDefault();
            if (existingForm != null)
            {
                // Nếu đã mở, đưa nó lên trên cùng
                existingForm.BringToFront();
            }
            else
            {
                // Nếu chưa mở, tạo mới và truyền quyền
                frmQLHopDong f = new frmQLHopDong(_userRole);
                f.Show();
            }
        }
        private void mnQLThanhToan_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem form frmQLThanhToan đã mở chưa
            var existingForm = Application.OpenForms.OfType<frmQLThanhToan>().FirstOrDefault();
            if (existingForm != null)
            {
                // Nếu đã mở, đưa nó lên trên cùng
                existingForm.BringToFront();
            }
            else
            {
                // Nếu chưa mở, tạo mới và truyền quyền
                frmQLThanhToan f = new frmQLThanhToan(_userRole);
                f.Show();
            }
        }
        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Lấy DataGridView hiện tại (cái đã gọi sự kiện này)
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            // Tăng độ rộng của cột tiêu đề hàng (RowHeader)
            // để có đủ chỗ cho các số (ví dụ: 100)
            if (dgv.Rows.Count > 99)
            {
                dgv.RowHeadersWidth = 65;
            }
            else
            {
                dgv.RowHeadersWidth = 55;
            }

            // Duyệt qua tất cả các hàng và gán số thứ tự
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                // Gán giá trị STT vào ô HeaderCell
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportToExcel(dgvPhong, "DanhSachPhong", "DS_Phong");
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