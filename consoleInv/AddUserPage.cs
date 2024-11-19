using MyClasses;

namespace consoleInv
{
    public class AddUserPage
    {
        private DbManager _dbManager;

        public AddUserPage()
        {
            _dbManager = new DbManager(Path.Combine(Directory.GetCurrentDirectory(), "DataBase.db"));
        }

        public void Run()
        {
            Console.Clear();

            Console.Write("Username: ");
            string username = Console.ReadLine() ?? "";

            Console.Write("Password: ");
            string password = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            string emailLine = Console.ReadLine() ?? "";
            Email email = Email.FromString(emailLine);

            User newUser = new User(0, username, password, email);
            if (_dbManager.AddUser(newUser))
                Console.WriteLine("User added successfully.");
            else
                Console.WriteLine("Error adding user.");
            Console.ReadLine();
        }


        public void Show()
        {
            List<User> users = _dbManager.GetUsers();
            if (users.Count == 0)
            {
                Console.WriteLine("No users to display.");
                return;
            }
            int maxUsernameLength = users.Max(user => user.Username.Length);
            int maxPasswordLength = users.Max(user => user.Password.Length);
            int maxEmailLength = users.Max(user => user.Email.ToString().Length);
            int boxWidth = Math.Max(50, "ID".Length + maxUsernameLength + maxPasswordLength + maxEmailLength + 15);
            string format = $"| {{0,-5}} | {{1,-{maxUsernameLength}}} | {{2,-{maxPasswordLength}}} | {{3,-{maxEmailLength}}} |";

            Console.WriteLine(new string('-', boxWidth));
            Console.WriteLine(format, "ID", "Username", "Password", "Email");
            Console.WriteLine(new string('-', boxWidth));

            foreach (User user in users)
                Console.WriteLine(format, user.ID, user.Username, user.Password, user.Email.ToString());

            Console.WriteLine(new string('-', boxWidth));
            Console.ReadLine();
        }

    }
}
