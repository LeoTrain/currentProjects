namespace TcpServer
{
    class Program
    {
        static async Task Main()
        {
            Server server = new Server("192.168.31.116", 6000);
            await server.StartAsync();
        }
    }
}
