// Thêm các using này vào đầu file
using QuanLyKTX.Services;
using QuanLyKTX.Models;
using System.Data;
using System.Globalization; // Cần thiết cho việc xử lý số (giá tiền)

namespace QuanLyKTX
{
    // Giả sử tên các control của bạn là:
    // txtSoPhong, cmbToa, numTang, cmbLoaiPhong, numSucChua,
    // txtGiaThang, cmbTrangThai, txtGhiChu, btnLuu, btnHuy

    public partial class frmChiTietPhong : Form
    {
        private int? _roomId; // null = Thêm mới, có giá trị = Sửa
        private RoomService _roomService;

        public frmChiTietPhong(int? roomId)
        {
            InitializeComponent();
            _roomId = roomId;
            _roomService = new RoomService();
        }

        private void frmChiTietPhong_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();

            if (_roomId != null) // Chế độ Sửa
            {
                lbTen.AccessibilityObject.Name = "Cập Nhật Thông Tin Phòng";
                this.Text = "Cập Nhật Thông Tin Phòng";
                var room = _roomService.GetRoomById(_roomId.Value);
                if (room != null)
                {
                    BindDataToForm(room);
                }
                txtSoPhong.ReadOnly = true; // Không cho sửa Số Phòng (khóa)
            }
            else // Chế độ Thêm
            {
                lbTen.AccessibilityObject.Name = "Thêm Phòng Mới";
                this.Text = "Thêm Phòng Mới";
                // Đặt giá trị mặc định
                cbTrangThai.SelectedItem = "Trống";
            }
        }

        private void LoadComboBoxData()
        {
            // Tải danh sách Tòa (Building)
            // Tốt hơn là lấy từ CSDL
            cbToa.DataSource = _roomService.GetBuildingList();

            // Tải danh sách Loại Phòng (RoomType)
            // Tốt hơn là lấy từ CSDL
            cbLoaiPhong.DataSource = _roomService.GetRoomTypeList();

            // Tải danh sách Trạng Thái
            // Danh sách này cố định, có thể hardcode
            cbTrangThai.DataSource = new List<string> { "Trống", "Còn chỗ", "Đầy", "Bảo trì" };
        }

        private void BindDataToForm(Room room)
        {
            txtSoPhong.Text = room.RoomNumber;
            cbToa.SelectedItem = room.Building;
            numTang.Value = room.Floor;
            cbLoaiPhong.SelectedItem = room.RoomType;
            numSucChua.Value = room.Capacity;
            // Hiển thị giá tiền dạng số, không có dấu phẩy, để dễ sửa
            txtGiaThang.Text = room.PricePerMonth.ToString();
            cbTrangThai.SelectedItem = room.Status;
            txtGhiChu.Text = room.Description;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
            {
                MessageBox.Show("Số phòng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbToa.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn Tòa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbLoaiPhong.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn Loại phòng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn Trạng thái.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra giá tiền
            if (!decimal.TryParse(txtGiaThang.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal price) || price < 0)
            {
                MessageBox.Show("Giá tiền không hợp lệ. Vui lòng chỉ nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private Room CollectDataFromForm()
        {
            Room room = new Room();
            room.RoomNumber = txtSoPhong.Text.Trim();
            room.Building = cbToa.SelectedItem.ToString();
            room.Floor = (int)numTang.Value;
            room.RoomType = cbLoaiPhong.SelectedItem.ToString();
            room.Capacity = (int)numSucChua.Value;
            // Parse giá tiền (đã validate ở trên)
            room.PricePerMonth = decimal.Parse(txtGiaThang.Text, NumberStyles.Any, CultureInfo.CurrentCulture);
            room.Status = cbTrangThai.SelectedItem.ToString();
            room.Description = txtGhiChu.Text.Trim();

            // Các trường này CSDL tự quản lý (nếu là chế độ thêm)
            // Hoặc sẽ được CSDL giữ nguyên (nếu là chế độ sửa)
            // room.CurrentOccupancy = ... (Logic này nên được xử lý khi thêm/xóa hợp đồng)

            return room;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return; // Dừng lại nếu dữ liệu không hợp lệ
            }

            try
            {
                Room roomData = CollectDataFromForm();

                if (_roomId == null) // Chế độ Thêm
                {
                    bool added = _roomService.AddRoom(roomData);
                    if (!added)
                    {
                        MessageBox.Show("Thêm không thành công. Số phòng này có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Thêm phòng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Chế độ Sửa
                {
                    roomData.RoomId = _roomId.Value; // Gán lại ID để biết sửa phòng nào
                    // Lấy số lượng SV hiện tại để không bị ghi đè về 0
                    var existingRoom = _roomService.GetRoomById(_roomId.Value);
                    roomData.CurrentOccupancy = existingRoom.CurrentOccupancy;

                    _roomService.UpdateRoom(roomData);
                    MessageBox.Show("Cập nhật thông tin phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Báo cho form cha (frmQLPhong) biết là đã thành công
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}