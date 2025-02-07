using System.Net.Sockets;

namespace ClientFramework.TCPClient
{
    public abstract class AbstractClient
    {
        protected int PORT;
        private string _msg;

        public AbstractClient(int port, string msg)
        {
            PORT = port;
            _msg = msg;
        }

        public void Connect()
        {

            TcpClient client = new TcpClient("127.0.0.1", PORT);

            Console.WriteLine("Connected:" + client.ToString());
            NetworkStream stream = client.GetStream();
            WriteClient(stream, _msg);


        }

        public abstract void WriteClient(NetworkStream stream, string msg, int byteLength = 1024);
    }
}