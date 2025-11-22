using Microsoft.EntityFrameworkCore;
using QuanLyKTX.Models; // Quan trọng: using thư mục Models
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyKTX.Services
{
    public class UserService
    {
        // Khởi tạo DbContext
        private readonly DormitoryDBContext _context;

        public UserService()
        {
            _context = new DormitoryDBContext();
        }

        // Hàm kiểm tra đăng nhập
        public User CheckLogin(string username, string password)
        {
            // Mã hóa mật khẩu MD5
            string hashedPassword = MD5Helper.Hash(password);

            // AsNoTracking() giúp đọc nhanh hơn
            return _context.Users.AsNoTracking().FirstOrDefault(u =>
                u.Username == username &&
                u.Password == hashedPassword &&
                u.IsActive == true);
        }
    }

    // Lớp này để xử lý mật khẩu MD5 (e10adc3949ba59abbe56e057f20f883e) của bạn
    public static class MD5Helper
    {
        public static string Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Chuyển byte array sang hex string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}