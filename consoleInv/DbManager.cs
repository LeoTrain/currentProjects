using Microsoft.Data.Sqlite;
using MyClasses;

namespace consoleInv
{
    public class DbManager : DatabaseManagerSQLite
    {
        public DbManager(string filePath) : base(filePath)
        {
            List<SqlColumnDefinition> columns = new List<SqlColumnDefinition>
            {
                new SqlColumnDefinition("ID", SqlType.INTEGER, "PRIMARY KEY AUTOINCREMENT"),
                new SqlColumnDefinition("Username", SqlType.TEXT, "NOT NULL"),
                new SqlColumnDefinition("Password", SqlType.TEXT, "NOT NULL"),
                new SqlColumnDefinition("Email", SqlType.TEXT, "NOT NULL"),

            };
            Connect();
            CreateTable("Users", columns);
            Close();
        }

        public bool AddUser(User user)
        {
            Dictionary<string, object> newUser = new Dictionary<string, object>
            {
                {"Username", user.Username},
                {"Password", user.Password},
                {"Email", user.Email.ToString() ?? "NULL"}
            };
            try
            {
                Connect();
                InsertData("Users", newUser);
                Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
                return false;
            }
        }

        public bool UserExists(string username)
        {
            Connect();
            string[] existingUsers = GetDataFromColumn("Users", "Username");
            Close();

            if (Array.Exists(existingUsers, user => user == username))
                return true;
            return false;
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>(); 
            Connect();
            string query = "SELECT * FROM Users";
            using (var command = new SqliteCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        User user = new User(
                                Convert.ToInt32(reader["ID"]),
                                reader["Username"].ToString() ?? "",
                                reader["Password"].ToString() ?? "",
                                Email.FromString(reader["Email"].ToString() ?? ""));
                        users.Add(user);
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine($"Exception occured : {exc.Message}");
                    }
                }
            }
            Close();
            return users;
        }
    }
}

