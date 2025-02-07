using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientFramework.Client
{
    public abstract class AbstractUDPClient
    {
        protected int PORT;
        private string _msg;

        public AbstractUDPClient(int port, string msg)
        {
            PORT = port;
            _msg = msg;
        }

        public void Connect()
        {

            UdpClient client = new UdpClient("192.168.1.255", 11000);



            byte[] sendbuf = Encoding.ASCII.GetBytes("Sender data over UDP"); 
           
            client.Send(sendbuf);

            Console.WriteLine("Message sent to the broadcast address");


        }

       
    }
}
