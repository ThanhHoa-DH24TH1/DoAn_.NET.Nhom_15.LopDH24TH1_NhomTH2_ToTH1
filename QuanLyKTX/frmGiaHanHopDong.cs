using System.Data;

namespace QuanLyKTX
{
    public partial class frmGiaHanHopDong : Form
    {
        // Thuộc tính để form mẹ (frmQLHopDong) lấy ngày mới
        public DateOnly NewEndDate { get; private set; }

        private DateOnly _oldEndDate;

        /// <summary>
        /// Hàm khởi tạo (constructor) nhận vào ngày kết thúc CŨ
        /// </summary>
        public frmGiaHanHopDong(DateOnly oldEndDate)
        {
            InitializeComponent();
            _oldEndDate = oldEndDate;
        }

        private void frmGiaHanHopDong_Load(object sender, EventArgs e)
        {
            // Cài đặt DateTimePicker
            // Mặc định gia hạn thêm 6 tháng
            dtpNewEndDate.Value = _oldEndDate.ToDateTime(TimeOnly.MinValue).AddMonths(6);

            // Ngày mới không được nhỏ hơn ngày cũ
            dtpNewEndDate.MinDate = _oldEndDate.ToDateTime(TimeOnly.MinValue).AddDays(1);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Lấy ngày mới từ DateTimePicker
            this.NewEndDate = DateOnly.FromDateTime(dtpNewEndDate.Value);

            // Báo cho form mẹ là đã "OK"
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}