namespace TcpServer
{
    class Program
    {
        static async Task Main()
        {
            Server server = new Server("127.0.0.1", 6000);
            await server.StartAsync();
        }
    }
}
