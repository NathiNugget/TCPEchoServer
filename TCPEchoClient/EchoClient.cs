using System.Net.Sockets;

namespace TCPEchoClient
{
    public class EchoClient
    {
        public EchoClient() { }
        public void Start()
        {
            using (TcpClient socket = new TcpClient("localhost", 7))
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                string str = "I'll send this message";

                sw.WriteLine(str);
                sw.Flush();

                String? inStr = sr.ReadLine();
                Console.WriteLine(inStr);
            }

        }
    }
}
