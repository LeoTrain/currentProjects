using MyClasses;

namespace consoleInv
{
    public class LoginPage
    {
        private string _username = "";
        private string _password = "";
        private DbManager _dbManager;

        public LoginPage()
        {
            string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "DataBase.db");
            _dbManager = new DbManager(dbPath);
        }

        public bool Show()
        {
            bool registered = false;
            while (!registered)
            {
                Console.Clear();
                Console.WriteLine("=== Welcome, please choose... ===");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("Q. Quit");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.D1)
                    registered = true;
                else if (keyInfo.Key == ConsoleKey.D2)
                    registered = Register();
                else if (keyInfo.Key == ConsoleKey.Q)
                    Environment.Exit(0);
            }

            bool correct = false;
            Console.Clear();
            Console.WriteLine("=== LOGIN ===");
            Console.Write("Enter your username: ");
            _username = Console.ReadLine() ?? "";

            Console.Write("Enter your password: ");
            _password = Console.ReadLine() ?? "";
            correct = Authenticate();
            if (!correct)
                Console.WriteLine("Wrong username or Password.");
            else
                Console.WriteLine("Authentification successfull.");
            return correct;
        }

        private bool Register()
        {
            Console.Clear();
            Console.Write("Enter a username: ");
            string username = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrEmpty(username))
            {
                Console.WriteLine("Username cannot be empty.");
                return false;
            }

            Console.Write("Enter a password: ");
            string password = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password cannot be empty.");
                return false;
            }

            Console.Write("Enter an email address: ");
            string emailInput = Console.ReadLine()?.Trim() ?? "";
            Email email;
            try
            {
                email = Email.FromString(emailInput ?? throw new ArgumentNullException());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid email: {ex.Message}");
                return false;
            }

            if (_dbManager.UserExists(username))
            {
                Console.WriteLine($"Username already exists: {username}");
                return false;
            }

            User newUser = new User(0, username, password, email);
            bool success = _dbManager.AddUser(newUser);

            if (success)
            {
                Console.WriteLine("Registration successful! You can now log in.");
                return true;
            }
            else
            {
                Console.WriteLine("Failed to register user. Please try again.");
                return false;
            }
        }

        public bool Authenticate()
        {
            _dbManager.Connect();
            string[] users = _dbManager.GetDataFromColumn("Users", "Username");
            string[] passwords = _dbManager.GetDataFromColumn("Users", "Password");
            _dbManager.Close();
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i] == _username && passwords[i] == _password)
                    return true;
            }
            return false;
        }
    }
}
