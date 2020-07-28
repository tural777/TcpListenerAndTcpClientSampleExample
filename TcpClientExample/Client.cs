using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpClientExample
{
    class Client
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient();

            var ip = IPAddress.Parse("192.168.1.105");
            var port = 27001;
            var ep = new IPEndPoint(ip, port);

            BinaryWriter bw = null;

            try
            {
                tcpClient.Connect(ep);

                if (tcpClient.Connected)
                {
                    Console.WriteLine($"Connected Server: {tcpClient.Client.RemoteEndPoint}");

                    while (true)
                    {

                        Console.WriteLine("Enter message: ");

                        var msg = Console.ReadLine();

                        //var bytes = Encoding.UTF8.GetBytes(msg);

                        var networkStream = tcpClient.GetStream();

                        bw = new BinaryWriter(networkStream);
                        bw.Write(msg);

                        //networkStream.Write(bytes, 0, bytes.Length);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
