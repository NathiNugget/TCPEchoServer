﻿using System.Net;
using System.Net.Sockets;

namespace TCPEchoServer
{
    public class EchoServer
    {
        private const int PORT = 7007;

        public EchoServer()
        {
        }

        public void Start()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, PORT);
            listener.Start();
            Console.WriteLine("Server started");

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
        }

        private void DoOneClient(TcpClient sock)
        {
            using (StreamReader sr = new StreamReader(sock.GetStream()))
            using (StreamWriter sw = new StreamWriter(sock.GetStream()))
            {
                sw.AutoFlush = true;
                Console.WriteLine("Handle one client");

                // simple echo
                String? s = sr.ReadLine();
                sw.WriteLine(s);
            }

        }
    }
}
