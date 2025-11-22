// Thêm các using này vào đầu file
using QuanLyKTX.Services;
using QuanLyKTX.Helpers;
using System.Data;

namespace QuanLyKTX
{

    public partial class frmQLHopDong : Form
    {
        private ContractService _contractService;
        private string _userRole;

        public frmQLHopDong(string userRole)
        {
            InitializeComponent();
            _userRole = userRole;
            _contractService = new ContractService();
        }

        private void frmQLHopDong_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadComboBoxes();
            LoadContracts();
        }

        private void SetupDataGridView()
        {
            // Giả sử cái vùng xám là DataGridView tên là dgvHopDong
            var dgv = (DataGridView)this.Controls["dgvHopDong"];

            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
        }

        private void LoadComboBoxes()
        {
            cmbTrangThai.DataSource = _contractService.GetStatusList();
            cmbTrangThai.SelectedIndex = 0;
        }

        private void LoadContracts()
        {
            string keyword = txtTimHD.Text.Trim();
            string status = cmbTrangThai.SelectedItem?.ToString() ?? "Tất cả";

            try
            {
                var dgv = (DataGridView)this.Controls["dgvHopDong"];
                var contracts = _contractService.GetContracts(keyword, status);

                dgv.DataSource = null;
                dgv.DataSource = contracts;

                // Định dạng cột
                dgv.Columns["ContractId"].Visible = false;
                dgv.Columns["StudentCode"].HeaderText = "Mã SV";
                dgv.Columns["StudentName"].HeaderText = "Tên Sinh Viên";
                dgv.Columns["RoomNumber"].HeaderText = "Số Phòng";
                dgv.Columns["StartDate"].HeaderText = "Ngày Bắt Đầu";
                dgv.Columns["EndDate"].HeaderText = "Ngày Kết Thúc";
                dgv.Columns["MonthlyFee"].HeaderText = "Phí Hàng Tháng";
                dgv.Columns["MonthlyFee"].DefaultCellStyle.Format = "N0";
                dgv.Columns["Status"].HeaderText = "Trạng Thái";

                dgv.Columns["StudentName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hợp đồng: " + ex.Message, "Lỗi");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadContracts();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimHD.Text = "";
            cmbTrangThai.SelectedIndex = 0;
            LoadContracts();
        }

        /// <summary>
        /// Nút "Tạo HĐ" -> Mở Form Chi Tiết
        /// </summary>
        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            // Chúng ta sẽ gọi form mới
            frmChiTietHopDong f = new frmChiTietHopDong();
            if (f.ShowDialog() == DialogResult.OK)
            {
                // Nếu tạo HĐ thành công, tải lại lưới
                LoadContracts();
            }
        }

        /// <summary>
        /// Nút "Thanh Lý" Hợp Đồng
        /// </summary>
        private void btnThanhLy_Click(object sender, EventArgs e)
        {
            var dgv = (DataGridView)this.Controls["dgvHopDong"];

            if (dgv.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng để thanh lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int contractId = (int)dgv.CurrentRow.Cells["ContractId"].Value;
            string status = dgv.CurrentRow.Cells["Status"].Value.ToString();

            if (status != "Đang hiệu lực")
            {
                MessageBox.Show("Hợp đồng này không ở trạng thái 'Đang hiệu lực', không thể thanh lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn thanh lý hợp đồng này? Hành động này sẽ cập nhật số chỗ trống của phòng.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bool success = _contractService.TerminateContract(contractId);
                    if (success)
                    {
                        MessageBox.Show("Thanh lý hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadContracts(); // Tải lại lưới
                    }
                    else
                    {
                        MessageBox.Show("Không thể thanh lý hợp đồng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thanh lý: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Nút "Gia Hạn"
        /// </summary>
        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            if (dgvHopDong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng để gia hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int contractId = (int)dgvHopDong.CurrentRow.Cells["ContractId"].Value;
            DateOnly oldEndDate = (DateOnly)dgvHopDong.CurrentRow.Cells["EndDate"].Value;

            // 1. Mở form popup để hỏi ngày mới
            frmGiaHanHopDong f = new frmGiaHanHopDong(oldEndDate);

            // 2. Nếu người dùng nhấn "Lưu" (OK)
            if (f.ShowDialog() == DialogResult.OK)
            {
                // 3. Lấy ngày mới từ form popup
                DateOnly newEndDate = f.NewEndDate;

                // 4. Gọi service để cập nhật
                try
                {
                    bool success = _contractService.ExtendContract(contractId, newEndDate);
                    if (success)
                    {
                        MessageBox.Show("Gia hạn hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadContracts(); // Tải lại lưới
                    }
                    else
                    {
                        MessageBox.Show("Gia hạn thất bại. Ngày mới phải sau ngày cũ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi gia hạn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
        private void mnQLPhong_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem form frmQLPhong đã mở chưa
            var existingForm = Application.OpenForms.OfType<frmQLPhong>().FirstOrDefault();
            if (existingForm != null)
            {
                // Nếu đã mở, đưa nó lên trên cùng
                existingForm.BringToFront();
            }
            else
            {
                // Nếu chưa mở, tạo mới và truyền quyền
                frmQLPhong f = new frmQLPhong(_userRole);
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

            ExcelHelper.ExportToExcel(dgvHopDong, "DanhSachHopDong", "DS_HopDong");
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