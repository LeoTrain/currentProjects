namespace MenuBuilder
{
  class Program
  {
      static void Main()
      {
          var loginMenu = new LoginMenu("LOGIN");
          bool logSucc = false;
          while (!logSucc)
          {
              logSucc = loginMenu.Display();
          }
          MessageBox.Display("SUCCESFULL", ["Yes !!!", "You passed the test !", "Press Enter to Continue"], MessageBoxType.Info);


          /*var mainMenu = new Menu("Menu Principal");*/
          /*mainMenu.AddOption("Option 1", () => Console.WriteLine("Action de l'option 1 exécutée !"));*/
          /*mainMenu.AddOption("Option 2", () => Console.WriteLine("Action de l'option 2 exécutée !"));*/
          /*mainMenu.AddOption("Quitter", () => Environment.Exit(0));*/
          /*mainMenu.AddTopScore(10);*/
          /**/
          /*while (true)*/
          /*{*/
          /*    mainMenu.Display();*/
          /*}*/
      }
  }
}
