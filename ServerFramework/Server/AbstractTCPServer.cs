using System.Net;
using System.Net.Sockets;

namespace ServerFramework.TCPServer
{
    public abstract class AbstractTCPServer
    {
        protected int PORT;

        public AbstractTCPServer(int port)
        {
            PORT = port;
        }

        public void Start()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, PORT);
            listener.Start();
            Console.WriteLine($"Server started, listening at PORT: {PORT}");
            Task.Run(() =>
            {
                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Client incoming");
                    Console.WriteLine($"remote (ip,port) = ({client.Client.RemoteEndPoint})");

                    Task.Run(() =>
                    {
                        TcpClient tmpClient = client;
                        DoOneClient(client);
                    });

                }
            });

        }

        private void DoOneClient(TcpClient sock)
        {
            using (StreamReader sr = new StreamReader(sock.GetStream()))
            using (StreamWriter sw = new StreamWriter(sock.GetStream()))
            {
                sw.AutoFlush = true;
                Console.WriteLine("Handle one client");

                TCPServerWork(sr, sw);
            }

        }

        public abstract void TCPServerWork(StreamReader sr, StreamWriter sw);
    }
}

