using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyKTX.Helpers
{
    public static class FormHelper
    {
        /// <summary>
        /// Bật/Tắt Chatbot và căn chỉnh đuôi bong bóng vào đúng vị trí mục tiêu
        /// </summary>
        /// <param name="targetPoint">Điểm trên màn hình mà đuôi bong bóng sẽ chỉ vào (thường là đỉnh giữa icon)</param>
        public static void ToggleChatbot(Point targetPoint)
        {
            var existingForm = Application.OpenForms.OfType<frmChatBot>().FirstOrDefault();

            if (existingForm != null && existingForm.Visible)
            {
                existingForm.Hide();
            }
            else
            {
                frmChatBot f = existingForm ?? new frmChatBot();

                // --- CẤU HÌNH KÍCH THƯỚC FORM ---
                // Phải khớp với kích thước bạn đã set trong frmChatbot.cs
                int formWidth = 636;
                int formHeight = 411;

                // --- CẤU HÌNH VỊ TRÍ ĐUÔI ---
                // Phải khớp với biến _tailPosition trong frmChatbot.cs
                int tailOffset = 178;

                // --- TÍNH TOÁN VỊ TRÍ FORM ---

                // 1. Tính X: Dịch form sang trái sao cho đuôi (tại px 60) trùng với mục tiêu
                int x = targetPoint.X - tailOffset;

                // 2. Tính Y: Đặt form nằm hoàn toàn phía trên mục tiêu
                int y = targetPoint.Y - formHeight;

                // 3. Xử lý tràn màn hình (nếu nút quá sát lề)
                var screen = Screen.FromPoint(targetPoint);
                if (x < screen.WorkingArea.Left) x = screen.WorkingArea.Left + 10;
                if (x + formWidth > screen.WorkingArea.Right) x = screen.WorkingArea.Right - formWidth - 10;
                if (y < screen.WorkingArea.Top) y = targetPoint.Y + 10; // Nếu sát mép trên quá thì hiện xuống dưới

                f.Location = new Point(x, y);

                f.Show();
                f.BringToFront();
            }
        }
    }
}