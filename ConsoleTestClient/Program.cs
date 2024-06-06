using ClientLib.Networking;

namespace ConsoleTestClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicNetworkTcpClient client = new BasicNetworkTcpClient();
            client.port = 8080;
            client.Init();
            client.Start();
            client.ConnectToServer();
            Console.WriteLine("Port:" + client.port);
            
            
            while (true) // Simulates Game Loop
            {
            }
            
        
        }
    }
}
