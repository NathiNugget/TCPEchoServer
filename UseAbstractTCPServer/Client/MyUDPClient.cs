using ClientFramework.Client;

namespace UseAbstractTCPServer.Client
{
    public class MyUDPClient : AbstractUDPClient
    {
        public MyUDPClient(int port, string msg) : base(port, msg)
        {
        }
    }
}
