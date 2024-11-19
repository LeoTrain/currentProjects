namespace consoleInv
{
    public class MainWindow
    {
        private AddUserPage _addUserPage;

        public MainWindow()
        {
            _addUserPage = new AddUserPage();
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Main Window ===");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Show Users");
                Console.WriteLine("Q. Quit");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Q)
                {
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                }
                else if (keyInfo.Key == ConsoleKey.D1)
                {
                    _addUserPage.Run();
                }
                else if (keyInfo.Key == ConsoleKey.D2)
                {
                    _addUserPage.Show();
                }
                Console.WriteLine($"You chose option: {keyInfo.Key}");
                Thread.Sleep(3000);
            }
        }
    }
}
