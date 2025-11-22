// Thêm các using này vào đầu file
using QuanLyKTX.Services;
using QuanLyKTX.Helpers;
using System;
using System.Collections.Generic; // Cần cho List
using System.Data;
using System.Drawing; // Using cho Font
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Using cho Chart

namespace QuanLyKTX
{

    // panelChartPlaceholder (Panel chứa biểu đồ)
    // *** dgvBaoCao *** (DataGridView ở dưới)

    public partial class frmBaoCao : Form
    {
        private InvoiceService _invoiceService;
        private ReportService _reportService;
        private string _userRole;
        private Chart chartDoanhThu;

        public frmBaoCao(string userRole)
        {
            InitializeComponent();
            _invoiceService = new InvoiceService();
            _reportService = new ReportService();
            _userRole = userRole;
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            SetupChartControl();
            LoadMonthComboBoxes();

            // =======================================================
            // == BỔ SUNG: Cấu hình ban đầu cho DataGridView ==
            SetupDataGridView();
            // =======================================================
        }

        // Tải danh sách tháng vào ComboBox
        private void LoadMonthComboBoxes()
        {
            var monthList = _invoiceService.GetBillingMonths();
            cbTuThang.DataSource = new List<string>(monthList);
            cbDenThang.DataSource = new List<string>(monthList);
            cbTuThang.SelectedIndex = 0;
            cbDenThang.SelectedIndex = 0;
        }

        // Cài đặt Chart (ĐÃ CÓ)

        private void SetupChartControl()
        {
            this.chartDoanhThu = new Chart();
            ChartArea chartArea = new ChartArea("MainArea");
            this.chartDoanhThu.ChartAreas.Add(chartArea);
            Title title = new Title("Báo Cáo Doanh Thu Thực Tế (Đã Thanh Toán)");
            title.Font = new Font("Arial", 12, FontStyle.Bold);
            this.chartDoanhThu.Titles.Add(title);
            this.chartDoanhThu.Legends.Add(new Legend("DefaultLegend"));
            chartDoanhThu.ChartAreas["MainArea"].AxisX.MajorGrid.Enabled = false;
            chartDoanhThu.ChartAreas["MainArea"].AxisX.Title = "Tháng";
            chartDoanhThu.ChartAreas["MainArea"].AxisY.Title = "Doanh Thu (VND)";
            chartDoanhThu.ChartAreas["MainArea"].AxisY.LabelStyle.Format = "N0";
            this.chartDoanhThu.Dock = DockStyle.Fill;
            if (this.Controls.ContainsKey("panelChartPlaceholder"))
            {
                this.panelChartPlaceholder.Controls.Add(this.chartDoanhThu);
            }
            else
            {
                MessageBox.Show("Lỗi Thiết Kế: Không tìm thấy 'panelChartPlaceholder'.", "Lỗi");
            }
        }

        // =======================================================
        // == HÀM MỚI: Cấu hình ban đầu cho DataGridView ==
        // =======================================================
        private void SetupDataGridView()
        {
            // Đảm bảo bạn có DataGridView tên là "dgvBaoCao"
            if (!this.Controls.ContainsKey("dgvBaoCao"))
            {
                MessageBox.Show("Lỗi Thiết Kế: Không tìm thấy 'dgvBaoCao'.", "Lỗi");
                return;
            }
            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.AllowUserToAddRows = false;
            dgvBaoCao.AllowUserToDeleteRows = false;
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        // =======================================================
        // == CẬP NHẬT: Nút "Làm Mới" sẽ tải cả Chart và Grid ==
        // =======================================================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            string startMonth = cbTuThang.SelectedItem?.ToString() ?? "Tất cả";
            string endMonth = cbDenThang.SelectedItem?.ToString() ?? "Tất cả";

            try
            {
                // 1. Tải dữ liệu TÓM TẮT cho Biểu đồ (Đã có)
                var chartData = _reportService.GetRevenueReport(startMonth, endMonth);
                LoadChart(chartData);

                // 2. Tải dữ liệu CHI TIẾT cho DataGridView (Mới)
                var gridData = _reportService.GetRevenueDetailsReport(startMonth, endMonth);
                LoadDataGridView(gridData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải báo cáo: " + ex.Message, "Lỗi");
            }
        }

        // Hàm vẽ Biểu đồ 
        private void LoadChart(List<RevenueByMonth> data)
        {
            if (data == null) return;

            this.chartDoanhThu.Series.Clear();
            Series series = new Series("Doanh Thu");

            // 1. Xác định loại biểu đồ từ ComboBox
            SeriesChartType chartType = SeriesChartType.Column; // Mặc định

            if (cmbLoaiBieuDo.SelectedItem != null)
            {
                string selectedType = cmbLoaiBieuDo.SelectedItem.ToString();
                if (selectedType.Contains("Cột")) chartType = SeriesChartType.Column;
                else if (selectedType.Contains("Đường")) chartType = SeriesChartType.Line;
                else if (selectedType.Contains("Tròn")) chartType = SeriesChartType.Pie;
                else if (selectedType.Contains("Miền")) chartType = SeriesChartType.Area;
            }

            series.ChartType = chartType;

            // 2. Cấu hình riêng cho từng loại
            if (chartType == SeriesChartType.Pie)
            {
                series.IsValueShownAsLabel = true;
                series.Label = "#VALX (#PERCENT)"; // Hiển thị Tên tháng + Phần trăm
                series.LegendText = "#VALX"; // Chú thích là Tên tháng
                this.chartDoanhThu.ChartAreas["MainArea"].AxisX.LabelStyle.Enabled = false; // Ẩn trục X
                this.chartDoanhThu.ChartAreas["MainArea"].AxisY.LabelStyle.Enabled = false; // Ẩn trục Y
            }
            else
            {
                series.LegendText = "Doanh thu (VND)";
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "N0";
                // Bật lại trục X, Y nếu chuyển từ Pie sang loại khác
                this.chartDoanhThu.ChartAreas["MainArea"].AxisX.LabelStyle.Enabled = true;
                this.chartDoanhThu.ChartAreas["MainArea"].AxisY.LabelStyle.Enabled = true;
            }

            // 3. Gán dữ liệu
            series.Points.DataBind(data, "Month", "Revenue", "");

            // Hiệu ứng thị giác (Marker cho biểu đồ đường)
            if (chartType == SeriesChartType.Line)
            {
                series.MarkerStyle = MarkerStyle.Circle;
                series.MarkerSize = 10;
                series.BorderWidth = 3;
            }

            this.chartDoanhThu.Series.Add(series);
            series.ToolTip = "Tháng #VALX: #VALY{N0} VND";
            this.chartDoanhThu.Invalidate();
        }

        // =======================================================
        // == HÀM MỚI: Tải và định dạng DataGridView ==
        // =======================================================
        private void LoadDataGridView(List<InvoiceViewModel> data)
        {
            // Gán dữ liệu
            dgvBaoCao.DataSource = null;
            dgvBaoCao.DataSource = data;

            // Định dạng cột (Giống frmQLThanhToan)
            try
            {
                dgvBaoCao.Columns["InvoiceId"].Visible = false; // Ẩn ID

                dgvBaoCao.Columns["StudentName"].HeaderText = "Tên Sinh Viên";
                dgvBaoCao.Columns["RoomNumber"].HeaderText = "Số Phòng";
                dgvBaoCao.Columns["BillingMonth"].HeaderText = "Tháng HĐ";
                dgvBaoCao.Columns["TotalAmount"].HeaderText = "Tổng Thu";
                dgvBaoCao.Columns["PaymentDate"].HeaderText = "Ngày Thanh Toán";
                dgvBaoCao.Columns["Status"].HeaderText = "Trạng Thái";

                // Ẩn các cột không cần thiết cho báo cáo này
                dgvBaoCao.Columns["PaidAmount"].Visible = false;
                dgvBaoCao.Columns["RemainingAmount"].Visible = false;
                dgvBaoCao.Columns["DueDate"].Visible = false;

                // Định dạng tiền
                dgvBaoCao.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";

                // Tự động căn chỉnh độ rộng
                dgvBaoCao.Columns["StudentName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvBaoCao.Columns["BillingMonth"].Width = 90;
                dgvBaoCao.Columns["RoomNumber"].Width = 90;
                dgvBaoCao.Columns["Status"].Width = 120;
                dgvBaoCao.Columns["TotalAmount"].Width = 120;
                dgvBaoCao.Columns["PaymentDate"].Width = 130;
            }
            catch (Exception ex)
            {
                // Có thể xảy ra lỗi nếu tên cột không khớp
                Console.WriteLine("Lỗi định dạng cột: " + ex.Message);
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
            // Xuất cái DataGridView (dgvBaoCao) 
            ExcelHelper.ExportToExcel(dgvBaoCao, "BaoCaoDoanhThu", "BaoCao_DoanhThu");
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