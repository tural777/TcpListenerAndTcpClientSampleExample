using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TcpListenerExample
{
    class Server
    {
        static void Main(string[] args)
        {
            var ip = IPAddress.Parse("192.168.1.105");
            var port = 27001;  //(anyPort)
            var ep = new IPEndPoint(ip, port);
            var tcpListener = new TcpListener(ep);
            tcpListener.Start();

            BinaryReader br = null;
            //BinaryWriter bw = null;

            try
            {


                while (true)
                {
                    Console.WriteLine($"Listening on {tcpListener.LocalEndpoint}");

                    TcpClient client = tcpListener.AcceptTcpClient();

                    Console.WriteLine($"{client.Client.RemoteEndPoint} connected!");

                    NetworkStream networkStream = client.GetStream();

                    br = new BinaryReader(networkStream);

                    while (true)
                    {
                        //example 1
                        //var buffer = new byte[1024];
                        //var lenght = networkStream.Read(buffer, 0, buffer.Length);
                        //var msg = Encoding.UTF8.GetString(buffer, 0, lenght);



                        //example with BinaryRead
                        var msg = br.ReadString();
                        Console.WriteLine($"Message: {msg}");
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
