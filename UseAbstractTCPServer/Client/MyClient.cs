using ClientFramework.TCPClient;
using System.Net.Sockets;
using System.Text;

namespace UseAbstractTCPServer.Client
{
    public class MyClient : AbstractClient
    {
        public MyClient(int port, string msg) : base(port, msg)
        {
        }

        public override void WriteClient(NetworkStream stream, string msg, int byteLength = 1024)
        {
            byte[] myWriteBuffer = Encoding.ASCII.GetBytes(msg + " was sent from MyClient\r\n");
            stream.Write(myWriteBuffer);
            stream.Flush();
            byte[] bytes = new byte[byteLength];
            _ = stream.Read(bytes, 0, byteLength);
            stream.Close();
            string received = Encoding.ASCII.GetString(bytes);
            Console.WriteLine($"Bytes read and message received: {received}");

        }
    }
}
