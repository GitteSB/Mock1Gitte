using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;      //required
using System.Net.Sockets;    //required
using System.Threading;
using Skat;

namespace TCPServer
{

    class Program
    {
        private class TcpServer
    {
        static TcpListener listener;
        static bool running = true;

        static void Main(string[] args)
        {
            listener = new TcpListener(IPAddress.Parse("10.200.132.40"), 7000);
            TcpClient client;
            listener.Start();

            while (running)
            {
                try
                {
                    client = listener.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem(ThreadProc, client);
                }

                    catch (Exception ex)
                    {
                    }

                }
            }
        }

        private static void ThreadProc(object obj)
        {
            try
            {
                TcpClient client = (TcpClient)obj;

                Console.WriteLine("New connection!");

                byte[] bytes = new byte[512];
                NetworkStream stream = client.GetStream();

                int i;

                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    string data = Encoding.ASCII.GetString(bytes, 0, i);

                    Console.WriteLine("Received:\n{0}", data);

                    byte[] msg = null;

                    var split = data.Split(' ');

                    if (split[0] == "ElBil")
                    {
                        int price = int.Parse(split[1]);
  
                            Afgift afgift = new Afgift();
                            data = Afgift.elBilAfgift(price).ToString();
                    }
                    else if (split[0] == "Bil")
                    {
                        int price = int.Parse(split[1]);

                        Afgift afgift = new Afgift();
                            data = Afgift.bilAfgift(price).ToString();
                    }
                    else
                    {
                        data = "Incorrect format.";
                    }

                    msg = Encoding.ASCII.GetBytes(data);

                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent:\n{0}", data);
                    break;
                }

                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}



