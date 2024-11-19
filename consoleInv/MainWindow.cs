namespace consoleInv
{
    public class MainWindow
    {
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Main Window ===");
            Console.WriteLine("Welcome to the main application!");
            Console.WriteLine("Press Q to quit.");

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Show Users");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Q)
                {
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                }

                Console.WriteLine($"You chose option: {keyInfo.Key}");
            }
        }
    }
}
