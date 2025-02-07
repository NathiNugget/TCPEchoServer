using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerFramework.AbstractUDPServer
{
    public abstract class AbstractUDPServer
    {
        protected int PORT;

        public AbstractUDPServer(int port)
        {
            PORT = port;
        }

        public void Start()
        {
            
            UdpClient listener = new UdpClient(11000);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 11000);

            
                try
                {
                    while (true)
                    {
                        Console.WriteLine("Waiting for broadcast");
                        byte[] bytes = listener.Receive(ref groupEP);

                        Console.WriteLine($"Received broadcast from {groupEP} :");
                        Console.WriteLine($" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    listener.Close();
                }
            


        }

        protected abstract string FormatData(byte[] bytes, int length);




    }
}


