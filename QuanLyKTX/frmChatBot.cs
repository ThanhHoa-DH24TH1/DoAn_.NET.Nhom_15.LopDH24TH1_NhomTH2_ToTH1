using QuanLyKTX.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKTX
{

    public partial class frmChatBot : Form
    {
        private WeatherService _weatherService;
        public frmChatBot()
        {
            InitializeComponent();
            _weatherService = new WeatherService();
           
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        // Sự kiện khi nhấn chuột xuống Form -> Cho phép kéo đi
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void frmChatBot_Load(object sender, EventArgs e)
        {
            this.Text = "Trợ Lý Ảo - Dự Báo Thời Tiết";
            AddBotMessage("Xin chào! Tôi là trợ lý dự báo thời tiết.\nHãy nhập tên thành phố bạn muốn xem (Ví dụ: Ha Noi, Da Nang)..."); 
            rtbChatHistory.ReadOnly = true;
            txtInput.Focus();
        }
        private void AddMessage(string sender, string message, Color color)
        {
            if (rtbChatHistory == null) return;

            rtbChatHistory.SelectionStart = rtbChatHistory.TextLength;
            rtbChatHistory.SelectionLength = 0;

            rtbChatHistory.SelectionColor = color;
            rtbChatHistory.SelectionFont = new Font(rtbChatHistory.Font, FontStyle.Bold);
            rtbChatHistory.AppendText($"{sender}: ");

            rtbChatHistory.SelectionColor = Color.Black;
            rtbChatHistory.SelectionFont = new Font(rtbChatHistory.Font, FontStyle.Regular);
            rtbChatHistory.AppendText($"{message}\n\n");

            rtbChatHistory.ScrollToCaret();
        }

        private void AddUserMessage(string message)
        {
            AddMessage("Bạn", message, Color.Blue);
        }

        private void AddBotMessage(string message)
        {
            AddMessage("Bot", message, Color.Green);
        }

        // Sự kiện nhấn nút Gửi
        private async void btnSend_Click(object sender, EventArgs e)
        {
            string city = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(city)) return;

            // 1. Hiển thị tin nhắn của người dùng
            try
            {
                // 1. Hiển thị tin nhắn của người dùng
                AddUserMessage(city);
                txtInput.Clear();

                // Disable nút gửi để tránh spam
                btnSend.Enabled = false;

                // Hiển thị trạng thái đang xử lý (tùy chọn)
                // lblStatus.Text = "Đang trả lời...";

                // 2. Gọi API (await để không bị đơ form)
                // ĐẢM BẢO _weatherService KHÔNG NULL
                if (_weatherService == null)
                    _weatherService = new WeatherService();

                string response = await _weatherService.GetWeatherAsync(city);

                // 3. Hiển thị câu trả lời của Bot
                AddBotMessage(response);
            }
            catch (Exception ex)
            {
                AddBotMessage($"Đã xảy ra lỗi: {ex.Message}");
            }
            finally
            {
                // Bật lại nút gửi
                btnSend.Enabled = true;
                txtInput.Focus();
            }
        }

        // Xử lý phím Enter
        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend.PerformClick();
                e.SuppressKeyPress = true; // Ngăn tiếng "ding" của Windows
            }
        }
    }
}
