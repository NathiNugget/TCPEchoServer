using ClientFramework.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseAbstractTCPServer.Client
{
    public class MyUDPClient : AbstractUDPClient
    {
        public MyUDPClient(int port, string msg) : base(port, msg)
        {
        }
    }
}
