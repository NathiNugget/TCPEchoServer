// See https://aka.ms/new-console-template for more information

using UseAbstractTCPServer.Server;

int PORT = 727;
MyServer server = new MyServer(PORT);


server.Start();


