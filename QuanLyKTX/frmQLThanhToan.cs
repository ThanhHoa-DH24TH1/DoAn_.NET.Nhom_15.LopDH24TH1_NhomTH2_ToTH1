
using QuanLyKTX.Helpers;
using QuanLyKTX.Models; // Cần cho InvoiceViewModel
using QuanLyKTX.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyKTX
{
    public partial class frmQLThanhToan : Form
    {
        private InvoiceService _invoiceService;
        private string _userRole;

        // Giả sử tên các control:
        // dgvInvoices, txtTimKiem, cmbThang, cmbTrangThai
        // btnTim, btnLamMoi, btnThem, btnXoa, btnSua, btnThanhToan

        public frmQLThanhToan(string userRole)
        {
            InitializeComponent();
            _invoiceService = new InvoiceService();
            this._userRole = userRole;
        }

        private void frmQLThanhToan_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadInvoices();
            SetupDataGridView();
        }


        /// <summary>
        /// Tải dữ liệu cho các ComboBox
        /// </summary>
        private void LoadComboBoxes()
        {
            // Tải ComboBox Tháng
            var months = _invoiceService.GetBillingMonths(); // Đã bao gồm "Tất cả"
            cbThang.DataSource = months;
            cbThang.SelectedIndex = 0;

            // Tải ComboBox Trạng Thái
            var statuses = new List<string> { "Tất cả", "Chưa thanh toán", "Đã thanh toán" };
            cbTrangThai.DataSource = statuses;
            cbTrangThai.SelectedIndex = 0;
        }

        /// <summary>
        /// Tải danh sách Hóa đơn lên DataGridView
        /// </summary>
        private void LoadInvoices()
        {
            try
            {
                string keyword = txtTim.Text.Trim();
                string billingMonth = cbThang.SelectedValue?.ToString() ?? "Tất cả";
                string status = cbTrangThai.SelectedValue?.ToString() ?? "Tất cả";

                // Sửa lỗi: Gọi hàm mới với đủ 3 tham số
                var invoices = _invoiceService.GetInvoices(keyword, billingMonth, status);
                dgvThanhToan.DataSource = invoices;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cài đặt hiển thị cho các cột
        /// </summary>
        private void SetupDataGridView()
        {
            var dgv = dgvThanhToan;
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = true; // Bật STT

            // Cột ẩn ID
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "InvoiceId",
                DataPropertyName = "InvoiceId",
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
                Name = "StudentName",
                HeaderText = "Tên Sinh Viên",
                DataPropertyName = "StudentName",
                Width = 150
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RoomNumber",
                HeaderText = "Phòng",
                DataPropertyName = "RoomNumber",
                Width = 70
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BillingMonth",
                HeaderText = "Tháng",
                DataPropertyName = "BillingMonth",
                Width = 70
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalAmount",
                HeaderText = "Tổng Tiền",
                DataPropertyName = "TotalAmount",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" },
                Width = 100
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RemainingAmount",
                HeaderText = "Còn Nợ",
                DataPropertyName = "RemainingAmount",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" },
                Width = 100
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Trạng Thái",
                DataPropertyName = "Status",
                Width = 120
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
            LoadInvoices();
        }

        // Nút Làm Mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTim.Text = "";
            cbThang.SelectedIndex = 0;
            cbTrangThai.SelectedIndex = 0;
            LoadInvoices();
        }

        // Nút Thêm (Mở form tạo HĐ hàng loạt)
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmChiTietHoaDon f = new frmChiTietHoaDon(_userRole);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadComboBoxes(); // Tải lại CSDL
                LoadInvoices();
            }
        }

        // Nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThanhToan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var invoiceId = (int)dgvThanhToan.CurrentRow.Cells["InvoiceId"].Value;
            var status = dgvThanhToan.CurrentRow.Cells["Status"].Value.ToString();

            if (status == "Đã thanh toán")
            {
                MessageBox.Show("Không thể xóa hóa đơn đã thanh toán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xóa hóa đơn này?\n(ID: {invoiceId})", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool success = _invoiceService.DeleteInvoice(invoiceId);
                if (success)
                {
                    MessageBox.Show("Xóa hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInvoices();
                }
                else
                {
                    MessageBox.Show("Xóa hóa đơn thất bại. (Hóa đơn không tồn tại hoặc đã được thanh toán).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Nút Sửa (Chưa implement)
        private void btnSua_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng sửa chi tiết hóa đơn (điện, nước) sẽ được cập nhật sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nút Thanh Toán (MỚI)
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvThanhToan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var invoiceId = (int)dgvThanhToan.CurrentRow.Cells["InvoiceId"].Value;
            var status = dgvThanhToan.CurrentRow.Cells["Status"].Value.ToString();

            ProcessPayment(invoiceId, status);
        }

        // Xử lý Double Click vào Grid
        private void dgvInvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Bỏ qua nếu click vào header

            var invoiceId = (int)dgvThanhToan.Rows[e.RowIndex].Cells["InvoiceId"].Value;
            var status = dgvThanhToan.Rows[e.RowIndex].Cells["Status"].Value.ToString();

            // Chỉ Admin mới được thanh toán
            if (_userRole == "Admin")
            {
                ProcessPayment(invoiceId, status);
            }
        }

        /// <summary>
        /// Hàm logic chung để xử lý thanh toán
        /// </summary>
        private void ProcessPayment(int invoiceId, string status)
        {
            if (status == "Đã thanh toán")
            {
                MessageBox.Show("Hóa đơn này đã được thanh toán rồi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Xác nhận thanh toán cho hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool success = _invoiceService.PayInvoice(invoiceId);
                if (success)
                {
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInvoices(); // Tải lại lưới
                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Đóng Form (Quan trọng)
        private void frmQLThanhToan_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Tắt toàn bộ ứng dụng (vì form Đăng nhập đang bị ẩn)
            Application.Exit();
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
        private void mnQLHopDong_Click(object sender, EventArgs e)
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
        private void mnQLPhong_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem form frmQLHopDong đã mở chưa
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
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportToExcel(dgvThanhToan, "DanhSachHoaDon", "DS_HoaDon");
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