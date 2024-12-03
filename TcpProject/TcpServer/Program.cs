namespace TcpServer
{
    class Program
    {
        static async Task Main()
        {
            Server server = new Server("192.168.1.108", 6000);
            await server.StartAsync();
        }
    }
}
