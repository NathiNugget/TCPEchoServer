using ServerFramework.TCPServer;

namespace UseAbstractTCPServer.Server
{
    public class MyServer : AbstractServer
    {

        public MyServer() : base()
        { }

        public override void TCPServerWork(StreamReader sr, StreamWriter sw)
        {
            string s = sr.ReadLine()!;
            string output = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (i % 2 == 0)
                {
                    output += char.ToLower(s[i]);
                }
                else
                {
                    output += char.ToUpper(s[i]);
                }
            }
            sw.WriteLine(output);
        }
    }
}
