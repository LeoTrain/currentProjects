namespace Client
{
   class Program
   {
       static async Task Main(string[] args)
       {
           Clients client = new Clients();
           await client.StartAsync();
       }
   }
}
