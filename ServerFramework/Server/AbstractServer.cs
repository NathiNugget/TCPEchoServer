using System.Net;
using System.Net.Sockets;

namespace ServerFramework.TCPServer
{
    public abstract class AbstractServer
    {
        protected int PORT;
        protected bool _running;
        protected int _attempts;
        protected string _password;
        private List<IPAddress> _addressesBanned;

        /// <summary>
        /// Abstract class to represent a server-implmentation
        /// </summary>
        /// <param name="port">Number to listen for connections</param>
        public AbstractServer(int port)
        {
            PORT = port;
            _running = true;
            _attempts = 3;
            _password = "swagster123";
            _addressesBanned = new List<IPAddress>();
        }

        /// <summary>
        /// Starts a TCP-listener to listen to connections on that port.
        /// Runs a new Task for each connected client as well as printing the client IP/port
        /// </summary>
        public void Start()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, PORT);
            listener.Start();
            Console.WriteLine($"Server started, listening at PORT: {PORT}");





            TcpListener stopListener = new TcpListener(IPAddress.Any, PORT + 1);
            stopListener.Start();
            Task.Run(() =>
            {
                while (_running)
                {
                    if (stopListener.Pending())
                    {
                        TcpClient client = stopListener.AcceptTcpClient();
                        if (_addressesBanned.Contains(((IPEndPoint)client.Client.RemoteEndPoint).Address!))
                        {
                            StreamWriter sw = new StreamWriter(client.GetStream());
                            sw.WriteLine("Du er banned, begone!");
                            sw.Flush();
                            client.Dispose(); 
                        }
                        else
                        {
                            if (HandleStopClient(client))
                            {
                                Thread.Sleep(5000);
                                _running = false;
                                client.Dispose();
                            }
                            else
                            {
                         
                                _addressesBanned.Add(((IPEndPoint)client.Client.RemoteEndPoint).Address);
                                client.Dispose();
                            }
                        }



                    }
                    else Thread.Sleep(1000);

                }
            });

            while (_running)
            {
                if (listener.Pending())
                {
                    TcpClient client = listener.AcceptTcpClient();
                    try
                    {
                        // This blocks and waits for a client to connect.

                        Console.WriteLine("Client incoming");
                        Console.WriteLine($"remote (ip, port) = ({client.Client.RemoteEndPoint})");

                        // Handle the client in a separate task to not block the listener
                        Task.Run(() =>
                        {
                            DoOneClient(client);
                        });
                    }
                    catch
                    {
                        Console.WriteLine("Client disconnected");
                    }
                }
                else
                {
                    Thread.Sleep(1000);
                }


            }










        }

        protected bool HandleStopClient(TcpClient client)
        {
            StreamWriter sw = new StreamWriter(client.GetStream());
            StreamReader sr = new StreamReader(client.GetStream());
            sw.AutoFlush = true;
            sw.WriteLine("Skriv adgangskode!");
            bool solved = false;
            string input;
            _attempts = 3; 
            while (_attempts > 0)
            {
                input = sr.ReadLine()!;
                if (input != _password) _attempts--;
                else
                {
                    solved = true;
                    sw.WriteLine("Du skrev rigtigt, server lukker nu ned..");
                    break;
                }
            }
            return solved;
        }


        protected void DoOneClient(TcpClient sock)
        {
            StreamReader sr = new StreamReader(sock.GetStream());
            StreamWriter sw = new StreamWriter(sock.GetStream());

            sw.AutoFlush = true;
            Console.WriteLine("Handle one client");

            TCPServerWork(sr, sw);
            sock.Dispose();

            sock.Close();




        }



        /// <summary>
        /// Method to mutate client data
        /// </summary>
        /// <param name="sr">Read data source</param>
        /// <param name="sw">Write data source</param>
        public abstract void TCPServerWork(StreamReader sr, StreamWriter sw);
    }
}

