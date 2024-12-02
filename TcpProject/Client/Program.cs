using Terminal.Gui;

namespace Client
{
   class Program
   {
       static void Main(string[] args)
       {
           Application.Init();
           Clients client = new Clients();
           /*await client.StartAsync();*/
           client.Start();
           Application.Shutdown();
       }
   }
}
