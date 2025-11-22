using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq; // Cần cài NuGet Newtonsoft.Json

namespace QuanLyKTX.Services
{
    public class WeatherService
    {
        // Thay thế bằng API Key của bạn
        // Lưu ý: Nếu bạn chưa thay key, hãy thay ngay nhé!
        private const string API_KEY = "f089b4038cfc72fe80104646d7a5682f"; // <--- THAY KEY CỦA BẠN VÀO ĐÂY
        private const string BASE_URL = "http://api.openweathermap.org/data/2.5/weather";

        private readonly HttpClient _httpClient;

        public WeatherService()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Lấy thông tin thời tiết theo tên thành phố
        /// </summary>
        public async Task<string> GetWeatherAsync(string city)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(city))
            {
                return "Vui lòng nhập tên thành phố.";
            }

            try
            {
                // Tạo URL request
                string url = $"{BASE_URL}?q={city}&appid={API_KEY}&units=metric&lang=vi";

                // Gọi API
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                // Đọc nội dung trả về
                string json = await response.Content.ReadAsStringAsync();

                // Parse JSON
                JObject data = JObject.Parse(json);

                // KIỂM TRA MÃ TRẠNG THÁI TỪ API (QUAN TRỌNG)
                // API OpenWeatherMap trả về mã lỗi trong field "cod"
                if (data["cod"] != null && data["cod"].ToString() != "200")
                {
                    // Lấy thông báo lỗi từ API
                    string message = data["message"]?.ToString() ?? "Lỗi không xác định";
                    return $"Không tìm thấy thông tin cho '{city}'.\nLỗi từ máy chủ: {message}";
                }

                // XỬ LÝ DỮ LIỆU AN TOÀN (Kiểm tra null từng bước)
                string description = "N/A";
                if (data["weather"] != null && data["weather"].HasValues)
                {
                    description = data["weather"][0]["description"]?.ToString();
                }

                string temp = data["main"]?["temp"]?.ToString() ?? "N/A";
                string humidity = data["main"]?["humidity"]?.ToString() ?? "N/A";
                string windSpeed = data["wind"]?["speed"]?.ToString() ?? "N/A";
                string cityName = data["name"]?.ToString() ?? city;

                // Tạo câu trả lời
                return $"🌤 Thời tiết tại {cityName}:\n" +
                       $"- Trạng thái: {description}\n" +
                       $"- Nhiệt độ: {temp}°C\n" +
                       $"- Độ ẩm: {humidity}%\n" +
                       $"- Gió: {windSpeed} m/s";
            }
            catch (HttpRequestException httpEx)
            {
                return $"Lỗi kết nối mạng: {httpEx.Message}";
            }
            catch (Exception ex)
            {
                // Bắt tất cả lỗi còn lại (bao gồm lỗi Null Reference)
                return $"Đã xảy ra lỗi khi xử lý dữ liệu: {ex.Message}";
            }
        }
    }
}