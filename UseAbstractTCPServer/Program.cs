// See https://aka.ms/new-console-template for more information

using System.Net.Sockets;
using System.Net;
using System.Text;
using UseAbstractTCPServer.Client;
using UseAbstractTCPServer.Server;

//const int PORT = 32;
//MyServer server = new MyServer(PORT);
//server.Start();
//MyClient client = new MyClient(PORT, "Skriv denne besked");
//client.Connect();

MyUDPServer server = new MyUDPServer(32); 
server.Start();

