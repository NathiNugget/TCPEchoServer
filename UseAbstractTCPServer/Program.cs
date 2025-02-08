// See https://aka.ms/new-console-template for more information

using UseAbstractTCPServer.Server;

int PORT = 727; // Not used in TCP-version since it uses XML-config instead. 
MyServer server = new MyServer();


server.Start();


