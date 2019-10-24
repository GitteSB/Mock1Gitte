using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var port = 7000;
                string local= "10.200.132.40";

                string message = " ";

                while (message != "")
                {
                    using (TcpClient client = new TcpClient(local, port))
                    {
                        var stream = client.GetStream();

                        Console.WriteLine("Send a message (format: 'biltype pris'):");
                        Console.WriteLine("Example: ElBil 150000");
                        Console.WriteLine("Example: Bil 250000");
                        message = Console.ReadLine();

                        var data = System.Text.Encoding.ASCII.GetBytes(message);

                        stream.Write(data, 0, data.Length);

                        Console.WriteLine("Sent:\n{0}", message);

                        data = new byte[256];

                        var responseData = string.Empty;

                        var bytes = stream.Read(data, 0, data.Length);
                        responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                        Console.WriteLine("Received:\n{0}", responseData);

                        stream.Close();
                        client.Close();
                    }
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.Read();
        }
    }
}

            