using System.Net.Sockets;

namespace ClientApp
{
    internal class Program
    {
        // Phương thức kết nối tới máy chủ và gửi/nhận thông điệp
        static void ConnectServer(string server, int port)
        {
            string message, responseData;
            int bytes;
            try
            {
                // Tạo một TcpClient để kết nối tới máy chủ và cổng đã chỉ định
                TcpClient client = new TcpClient(server, port);
                Console.Title = "Client Application";  // Đặt tiêu đề cho cửa sổ console
                NetworkStream stream = null;  // Khai báo một biến cho luồng mạng

                // Vòng lặp vô hạn để gửi thông điệp
                while (true)
                {
                    // Yêu cầu người dùng nhập một thông điệp
                    Console.Write("Nhập thông điệp <nhấn Enter để thoát>: ");
                    message = Console.ReadLine();

                    // Nếu người dùng không nhập gì (chuỗi rỗng), thoát khỏi vòng lặp
                    if (message == string.Empty)
                    {
                        break;
                    }

                    // Chuyển thông điệp thành mảng byte để truyền qua mạng
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes($"{message}");

                    // Lấy luồng mạng từ client để gửi dữ liệu
                    stream = client.GetStream();

                    // Gửi dữ liệu (thông điệp) qua luồng mạng
                    stream.Write(data, 0, data.Length);

                    // Hiển thị thông điệp đã gửi
                    Console.WriteLine("Đã gửi: {0}", message);

                    // Tạo một mảng byte để nhận dữ liệu phản hồi
                    data = new Byte[256];

                    // Đọc phản hồi từ luồng mạng
                    bytes = stream.Read(data, 0, data.Length);

                    // Chuyển mảng byte phản hồi thành chuỗi ASCII
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

                    // Hiển thị dữ liệu nhận được
                    Console.WriteLine("Đã nhận: {0}", responseData);
                }

                // Đóng kết nối client sau khi thoát khỏi vòng lặp
                client.Close();
            }
            catch (Exception e)
            {
                // Nếu có lỗi xảy ra, in ra thông báo lỗi
                Console.WriteLine(e);
            }
        }

        static void Main(string[] args)
        {
            string server = "127.0.0.1";  // Địa chỉ IP của máy chủ
            int port = 13000;             // Cổng kết nối
            ConnectServer(server, port);  // Gọi phương thức kết nối với máy chủ
        }
    }
}
