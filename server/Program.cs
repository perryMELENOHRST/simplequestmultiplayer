namespace Server
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.Title = "Game Server";
            GameServer.Start(4, 8080);
            Console.ReadKey();
        }
    }
}
