// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;
using TCPEchoServer;

Console.WriteLine("Hello, World!");

/*
EchoServer server = new EchoServer();
server.Start();
*/


Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

IPAddress broadcast = IPAddress.Parse("127.0.0.1");

byte[] sendbuf = Encoding.ASCII.GetBytes("swagster");
IPEndPoint ep = new IPEndPoint(broadcast, 11000);

s.SendTo(sendbuf, ep);
