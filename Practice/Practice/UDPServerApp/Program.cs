using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPServerApp
{
    internal class Program
    {
        // Cổng để máy chủ UDP lắng nghe
        const int listenPort = 11000;

        // Địa chỉ IP của máy chủ
        const string host = "127.0.0.1";

        // Phương thức để bắt đầu máy chủ lắng nghe các gói tin
        private static void StartListener()
        {
            string message; // Biến để lưu tin nhắn nhận được

            // Tạo một đối tượng UdpClient lắng nghe trên cổng đã chỉ định
            UdpClient listener = new UdpClient(listenPort);

            // Chuyển đổi địa chỉ IP từ chuỗi sang dạng IPAddress
            IPAddress address = IPAddress.Parse(host);

            // Tạo điểm cuối (endpoint) để liên kết với địa chỉ và cổng
            IPEndPoint remoteEndpoint = new IPEndPoint(address, listenPort);

            // Thiết lập tiêu đề cho cửa sổ console
            Console.Title = "UDP Server";

            // Hiển thị dòng thông báo phân cách
            Console.WriteLine(new string('*', 40));

            try
            {
                // Vòng lặp vô tận để lắng nghe các gói tin
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");

                    // Nhận dữ liệu từ một client và lưu thông tin endpoint của client
                    byte[] bytes = listener.Receive(ref remoteEndpoint);

                    // Chuyển đổi dữ liệu nhận được từ byte sang chuỗi
                    message = Encoding.ASCII.GetString(bytes, 0, bytes.Length);

                    // Hiển thị thông tin tin nhắn và địa chỉ nguồn
                    Console.WriteLine($"Received broadcast from {remoteEndpoint}: {message}");
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu xảy ra ngoại lệ
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // Đóng máy chủ khi kết thúc
                listener.Close();
            }
        }

        // Phương thức Main, điểm bắt đầu của chương trình
        static void Main(string[] args)
        {
            // Tạo một luồng để chạy phương thức StartListener
            Thread thread = new Thread(new ThreadStart(StartListener));

            // Bắt đầu luồng lắng nghe
            thread.Start();
        }
    }
}
