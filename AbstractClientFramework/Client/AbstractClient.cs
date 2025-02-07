using System.Net.Sockets;

namespace ClientFramework.TCPClient
{
    /// <summary>
    /// This class represents an abstract TCP Client to be overridden
    /// </summary>
    public abstract class AbstractClient
    {
        protected int PORT;
        private string _msg;

        /// <summary>
        /// Constructor for the abstract instance
        /// </summary>
        /// <param name="port">Port number to be used for the connection</param>
        /// <param name="msg">The message to be sent to the server</param>
        public AbstractClient(int port, string msg)
        {
            PORT = port;
            _msg = msg;
        }

        /// <summary>
        /// Method to connect and send data to a server
        /// </summary>
        public void Connect()
        {

            TcpClient client = new TcpClient("127.0.0.1", PORT);

            Console.WriteLine("Connected:" + client.ToString());
            NetworkStream stream = client.GetStream();
            WriteClient(stream, _msg);


        }


        /// <summary>
        /// Represents a method to write a message to the server
        /// </summary>
        /// <param name="stream">NetworkStream to send the message to</param>
        /// <param name="msg">Message to send</param>
        /// <param name="byteLength">Number of bytes to send to the server</param>
        public abstract void WriteClient(NetworkStream stream, string msg, int byteLength = 1024);
    }
}