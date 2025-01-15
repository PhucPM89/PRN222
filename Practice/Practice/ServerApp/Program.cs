using System.Net;
using System.Net.Sockets;

namespace ServerApp
{
    internal class Program
    {
        // Phương thức xử lý thông điệp từ client
        static void ProcessMessage(object parm)
        {
            string data;
            int count;
            try
            {
                // Chuyển đối tượng parm (client) thành TcpClient
                TcpClient client = parm as TcpClient;

                // Tạo mảng byte để chứa dữ liệu nhận từ client
                Byte[] bytes = new Byte[256];

                // Lấy luồng mạng từ client để đọc và ghi dữ liệu
                NetworkStream stream = client.GetStream();

                // Vòng lặp đọc dữ liệu từ client cho đến khi không còn dữ liệu
                while ((count = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Chuyển mảng byte nhận được thành chuỗi ASCII
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, count);
                    Console.WriteLine($"Đã nhận: {data} tại {DateTime.Now:t}");

                    // Chuyển dữ liệu nhận được thành chữ hoa
                    data = $"{data.ToUpper()}";

                    // Chuyển chuỗi kết quả thành mảng byte
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    // Gửi dữ liệu đã xử lý lại cho client
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine($"Đã gửi: {data}");
                }

                // Đóng kết nối client sau khi xử lý xong
                client.Close();
            }
            catch (Exception ex)
            {
                // Nếu có lỗi xảy ra, in ra thông báo lỗi
                Console.WriteLine(ex.ToString());
            }
        }

        // Phương thức thực thi server, chờ kết nối từ client
        static void ExecuteServer(string host, int port)
        {
            int Count = 0;
            TcpListener server = null;
            try
            {
                // Đặt tiêu đề cho cửa sổ console
                Console.Title = "Server Application";

                // Chuyển địa chỉ IP của máy chủ thành đối tượng IPAddress
                IPAddress localAddr = IPAddress.Parse(host);

                // Khởi tạo TcpListener để lắng nghe kết nối từ client
                server = new TcpListener(localAddr, port);

                // Bắt đầu lắng nghe kết nối
                server.Start();

                Console.WriteLine(new string('*', 40));
                Console.WriteLine("Đang chờ kết nối...");

                // Vòng lặp vô hạn để tiếp nhận kết nối từ client
                while (true)
                {
                    // Chấp nhận kết nối từ client
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine($"Số lượng client kết nối: {++Count}");
                    Console.WriteLine(new string('*', 40));

                    // Khởi tạo một luồng mới để xử lý client
                    Thread thread = new Thread(new ParameterizedThreadStart(ProcessMessage));

                    // Bắt đầu luồng xử lý cho client đã kết nối
                    thread.Start(client);
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi xảy ra, in ra thông báo lỗi
                Console.WriteLine(ex.ToString());
            }
        }

        static void Main(string[] args)
        {
            string host = "127.0.0.1";  // Địa chỉ IP của máy chủ
            int port = 13000;           // Cổng kết nối
            ExecuteServer(host, port);  // Gọi phương thức thực thi server
        }
    }
}
