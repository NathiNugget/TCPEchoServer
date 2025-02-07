using ServerFramework.AbstractUDPServer;
using System.Text;

namespace UseAbstractTCPServer.Server
{
    public class MyUDPServer : AbstractUDPServer
    {
        public MyUDPServer(int port) : base(port)
        {
        }

        protected override string FormatData(byte[] bytes, int length) => Encoding.ASCII.GetString(bytes, 0, length).ToUpper();



    }
}
