namespace MenuFramework
{
  class Program
  {
      static void Main()
      {
            var options = new Dictionary<string, Action>
            {
                { "Option 1", () => ShowNewWindow() },
                { "Option 2", () => Console.Clear() },
                { "Exit", () => Environment.Exit(0) }
            };
            MenuWindow window = new MenuWindow(50, 20, options);
            window.Show();
      }

        static void ShowNewWindow()
        {
           Window newWindow = new Window(); 
           newWindow.Show();
        }
  }
}
