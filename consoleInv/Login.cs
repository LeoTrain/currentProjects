using MyClasses;

namespace consoleInv
{
    public class LoginPage
    {
        private string _username = "";
        private string _password = "";
        private DbManager dbManager;

        public LoginPage()
        {
            string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "DataBase.db");
            dbManager = new DbManager(dbPath);
        }

        public bool Show()
        {
            dbManager.PrintUsers();
            bool correct = false;

            Console.Clear();
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

        public bool Authenticate()
        {
            dbManager.Connect();
            string[] users = dbManager.GetDataFromColumn("Users", "Username");
            string[] passwords = dbManager.GetDataFromColumn("Users", "Password");
            dbManager.Close();
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i] == _username && passwords[i] == _password)
                    return true;
            }
            return false;
        }

        public void AddUser()
        {
            User user1 = new User(0, "leo", "123", new Email("leo", "leoland", "com"));
            if (!dbManager.AddUser(user1))
                Console.WriteLine("Error adding user");
            else
                Console.WriteLine("User added !!!");


        }

    }
}
