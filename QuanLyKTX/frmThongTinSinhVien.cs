// Thêm các using này vào đầu file
using QuanLyKTX.Services;
using System;
using System.Data;
using System.Globalization; // Cần cho Format tiền
using System.Linq;
using System.Windows.Forms;

namespace QuanLyKTX
{
    public partial class frmThongTinSinhVien : Form
    {
        // Biến để lưu mã sinh viên được truyền từ form Đăng nhập
        private string _studentCode;

        // Service
        private StudentService _studentService;
        private InvoiceService _invoiceService;

        // Hàm khởi tạo (Constructor) nhận mã sinh viên
        public frmThongTinSinhVien(string studentCode)
        {
            InitializeComponent();
            this._studentCode = studentCode;
            _studentService = new StudentService();
            _invoiceService = new InvoiceService();
        }

        // Hàm Form_Load: Chạy khi form được tải lên
        private void frmThongTinSinhVien_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_studentCode))
            {
                MessageBox.Show("Không có thông tin sinh viên để hiển thị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Tải 3 phần thông tin
            LoadStudentInfo();
            LoadContractAndRoomInfo();
            LoadInvoiceHistory();

            // Cài đặt cho DataGridView
            SetupDataGridView();
        }

        /// <summary>
        /// Tải thông tin cá nhân của sinh viên
        /// </summary>
        private void LoadStudentInfo()
        {
            // Giả sử tên các TextBox của bạn là:
            // txtMSSV, txtHoTen, txtNgaySinh, txtGioiTinh, txtSDT, txtEmail, txtKhoa, txtLop
            try
            {
                var student = _studentService.GetStudentByCode(_studentCode);
                if (student != null)
                {
                    // Gán text cho các TextBox (và đặt chúng ở chế độ chỉ xem)
                    txtMSSV.Text = student.StudentCode;
                    txtHoTen.Text = student.FullName;
                    txtNgaySinh.Text = student.DateOfBirth.ToString("dd/MM/yyyy");
                    txtGioiTinh.Text = student.Gender;
                    txtSDT.Text = student.PhoneNumber ?? "Chưa cập nhật";
                    txtEmail.Text = student.Email ?? "Chưa cập nhật";
                    txtKhoa.Text = student.Faculty ?? "Chưa cập nhật";
                    txtLop.Text = student.Class ?? "Chưa cập nhật";

                    // (Bạn có thể thêm code để vô hiệu hóa các TextBox này)
                    // Ví dụ: txtMSSV.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin sinh viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin sinh viên: {ex.Message}");
            }
        }

        /// <summary>
        /// Tải thông tin hợp đồng, phòng ở và BẠN CÙNG PHÒNG
        /// </summary>
        private void LoadContractAndRoomInfo()
        {
            // Giả sử tên các control của bạn là:
            // txtSoPhong, txtToa, txtTang, txtLoaiPhong, txtGiaThue
            // txtNgayBatDau, txtNgayKetThuc, txtTienCoc
            // lbRoomMate (Đây là một ListBox)
            try
            {
                var contractInfo = _studentService.GetActiveContractByStudentCode(_studentCode);
                if (contractInfo != null)
                {
                    // Tải thông tin phòng
                    txtSoPhong.Text = contractInfo.RoomNumber;
                    txtToa.Text = contractInfo.Building;
                    txtTang.Text = contractInfo.Floor.ToString();
                    txtLoaiPhong.Text = contractInfo.RoomType;
                    txtGiaThue.Text = contractInfo.MonthlyFee.ToString("N0", new CultureInfo("vi-VN")) + " VNĐ/tháng";

                    // Tải thông tin hợp đồng
                    txtStartDay.Text = contractInfo.StartDate.ToString("dd/MM/yyyy");
                    txtEndDay.Text = contractInfo.EndDate.ToString("dd/MM/yyyy");
                    txtTienCoc.Text = contractInfo.Deposit.ToString("N0", new CultureInfo("vi-VN")) + " VNĐ";

                    // Tải thông tin bạn cùng phòng
                    LoadRoommates(contractInfo.RoomId, contractInfo.StudentId);
                }
                else
                {
                    // Xử lý trường hợp sinh viên không có hợp đồng
                    txtSoPhong.Text = "Không có hợp đồng";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin hợp đồng: {ex.Message}");
            }
        }

        /// <summary>
        /// Tải danh sách bạn cùng phòng vào ListBox
        /// </summary>
        private void LoadRoommates(int roomId, int currentStudentId)
        {
            try
            {
                // Giả sử ListBox của bạn tên là lbRoomMate
                lbRoomMate.Items.Clear();
                var roommates = _studentService.GetRoommates(roomId, currentStudentId);
                if (roommates.Any())
                {
                    foreach (var name in roommates)
                    {
                        lbRoomMate.Items.Add(name);
                    }
                }
                else
                {
                    lbRoomMate.Items.Add("Bạn là người duy nhất trong phòng này.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bạn cùng phòng: {ex.Message}");
            }
        }

        /// <summary>
        /// Tải lịch sử hóa đơn
        /// </summary>
        private void LoadInvoiceHistory()
        {
            // Giả sử DataGridView của bạn tên là dgvLichSuHoaDon
            try
            {
                var history = _invoiceService.GetInvoicesForStudent(_studentCode);
                dgvLichSuHoaDon.DataSource = history;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lịch sử hóa đơn: {ex.Message}");
            }
        }

        /// <summary>
        /// Cài đặt các cột cho DataGridView
        /// </summary>
        private void SetupDataGridView()
        {
            var dgv = dgvLichSuHoaDon; // Gõ tắt
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            // Cài đặt cho STT (nếu bạn có dùng)
            dgv.RowHeadersVisible = true;
            dgv.RowHeadersWidth = 55;

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BillingMonth",
                HeaderText = "Tháng HĐ",
                DataPropertyName = "BillingMonth",
                Width = 100
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalAmount",
                HeaderText = "Tổng Tiền",
                DataPropertyName = "TotalAmount",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Trạng Thái",
                DataPropertyName = "Status",
                Width = 120
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PaymentDate",
                HeaderText = "Ngày Thanh Toán",
                DataPropertyName = "PaymentDate",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 120
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Fill",
                HeaderText = "",
                DataPropertyName = "",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Gán sự kiện vẽ STT (nếu bạn đã copy hàm này)
            dgv.DataBindingComplete += dgv_DataBindingComplete;
        }

        // HÀM VẼ SỐ THỨ TỰ (Copy từ các Form khác)
        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        // HÀM ĐÓNG FORM (Quan trọng)
        // Khi sinh viên tắt form này, ứng dụng phải tắt hoàn toàn
        private void frmThongTinSinhVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Tắt toàn bộ ứng dụng (vì form Đăng nhập đang bị ẩn)
            Application.Exit();
        }

        private void frmThongTinSinhVien_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}