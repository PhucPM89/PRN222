using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPClientApp
{
    internal class Program
    {
        // Phương thức để kết nối tới máy chủ UDP và gửi tin nhắn
        static void ConnectServer(string host, int port)
        {
            // Tạo một đối tượng UdpClient
            UdpClient client = new UdpClient();

            // Chuyển đổi địa chỉ IP từ chuỗi sang dạng IPAddress
            IPAddress address = IPAddress.Parse(host);

            // Tạo điểm cuối (endpoint) với địa chỉ IP và cổng của máy chủ
            IPEndPoint remoteEndpoint = new IPEndPoint(address, port);

            string message; // Biến để lưu tin nhắn gửi
            int count = 0;  // Biến đếm số tin nhắn đã gửi
            bool done = false; // Biến kiểm tra khi nào dừng gửi tin nhắn

            // Thiết lập tiêu đề cho cửa sổ console
            Console.Title = "UDP Client";

            try
            {
                // Hiển thị dòng thông báo phân cách
                Console.WriteLine(new string('*', 40));

                // Kết nối đến máy chủ qua endpoint đã định nghĩa
                client.Connect(remoteEndpoint);

                // Vòng lặp để gửi tin nhắn
                while (!done)
                {
                    // Tạo tin nhắn với số thứ tự
                    message = $"Message {++count:D2}";

                    // Mã hóa tin nhắn sang dạng byte
                    byte[] sendBytes = Encoding.ASCII.GetBytes(message);

                    // Gửi tin nhắn qua UDP
                    client.Send(sendBytes, sendBytes.Length);

                    // Hiển thị tin nhắn đã gửi
                    Console.WriteLine($"Sent: {message}");

                    // Chờ 2 giây trước khi gửi tin nhắn tiếp theo
                    Thread.Sleep(2000);

                    // Dừng vòng lặp sau khi gửi đủ 10 tin nhắn
                    if (count == 10)
                    {
                        done = true;
                        Console.WriteLine("Done");
                    }
                }
            }
            catch (SocketException e)
            {
                // Xử lý lỗi nếu có ngoại lệ xảy ra trong khi gửi tin
                Console.WriteLine(e.Message);
            }
            finally
            {
                // Đóng kết nối UDP
                client.Close();
            }
        }

        // Phương thức Main, điểm bắt đầu của chương trình
        static void Main(string[] args)
        {
            // Địa chỉ IP và cổng của máy chủ
            string host = "127.0.0.1";
            int port = 11000;

            // Gọi phương thức để kết nối đến máy chủ
            ConnectServer(host, port);

            // Dừng chương trình cho đến khi nhấn phím
            Console.Read();
        }
    }
}
