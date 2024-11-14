using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.Threading;

namespace WpfApp1
{
    internal class DataBaseManager
    {
        private string _connectionString;
        public DataBaseManager()
        {
            string dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InventoryApp.db");

            if (!File.Exists(dbFilePath))
                Console.WriteLine($"Database file not found at {dbFilePath}");

            _connectionString = $"Data Source={dbFilePath};";
            InitializeDatabase();
        }

        public void InitializeDatabase()
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string createTabelQuerry = @"
                                CREATE TABLE IF NOT EXISTS Customers (
                                    CustomerID INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Name TEXT NOT NULL,
                                    Email TEXT NOT NULL UNIQUE,
                                    PasswordHash TEXT NOT NULL
                                    );";

                using (SqliteCommand command = new SqliteCommand(createTabelQuerry, connection))
                    command.ExecuteNonQuery();
            }
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string createTabelQuerry = @"
                                CREATE TABLE IF NOT EXISTS Products (
                                    ProductID INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Name TEXT NOT NULL,
                                    Definition TEXT NOT NULL UNIQUE,
                                    Price REAL NOT NULL,
                                    Amount INTEGER NOT NULL
                                    );";

                using (SqliteCommand command = new SqliteCommand(createTabelQuerry, connection))
                    command.ExecuteNonQuery();
            }
        }

        public bool CustomerNameExists(string name)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string userInDatabaseQuerry = "SELECT COUNT(1) FROM Customers WHERE Name = @Name";
                using (SqliteCommand command = new SqliteCommand(userInDatabaseQuerry, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public bool NameAndPasswordCorrespond(string name, string password)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string userAndPswdInDatabaseQuerry = "SELECT COUNT(1) FROM Customers WHERE Name = @Name AND PasswordHash = @Password";
                using (SqliteCommand command = new SqliteCommand(userAndPswdInDatabaseQuerry, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Password", password);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public bool AddProduct(string name, string definition, double price, int amount)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string insertQuerry = "INSERT INTO Products (ProductID, Name, Definition, Price, Amount) VALUES (@ProductID, @Name, @Definition, @Price, @Amount)";

                using (SqliteCommand command = new SqliteCommand(insertQuerry, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", GetLatestProductID() + 1);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Definition", definition);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Amount", amount);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool AddCustomer(string name, string email, string passwordHash)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string insertQuerry = "INSERT INTO Customers (CustomerID, Name, Email, PasswordHash) VALUES (@CustomerID, @Name, @Email, @PasswordHash)";
                
                using (SqliteCommand command = new SqliteCommand(insertQuerry, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", GetLatestUserID()+1);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool DeleteCustomer(string id)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string deleteQuerry = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
                using (SqliteCommand cmd = new SqliteCommand(deleteQuerry, connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        public bool ModifyName(string id, string newName)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string modifyQuerry = "UPDATE Customers SET Name = @NewName WHERE CustomerID = @CustomerID";
                using (SqliteCommand cmd = new SqliteCommand(modifyQuerry, connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", id);
                    cmd.Parameters.AddWithValue("@NewName", newName);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        public bool ModifyMail(string id, string newMail)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string modifyQuerry = "UPDATE Customers SET EMail = @NewMail WHERE CustomerID = @CustomerID";
                using (SqliteCommand cmd = new SqliteCommand(modifyQuerry, connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", id);
                    cmd.Parameters.AddWithValue("@NewMail", newMail);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        private long GetLatestUserID()
        {
            long takeOut;
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string selectQuerry = "SELECT MAX(CustomerID) FROM Customers";
                using (SqliteCommand command = new SqliteCommand(selectQuerry, connection))
                {
                    object result = command.ExecuteScalar() ?? 0;
                    if (result is long longResult)
                    {
                        takeOut = Convert.ToInt32(longResult);
                    }
                    else
                    {
                        takeOut = Convert.ToInt32(result);
                    }
                }
            }
            return takeOut;
        }

        private long GetLatestProductID()
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string selectQuerry = "SELECT MAX(ProductID) FROM Products";
                using (SqliteCommand command = new SqliteCommand(selectQuerry, connection))
                {
                    object result = command.ExecuteScalar() ?? 0;
                    if (result == null || result == DBNull.Value)
                        return 0;
                    else
                        return Convert.ToInt64(result);
                }
            }
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT CustomerID, Name, Email, PasswordHash FROM Customers";

                using (SqliteCommand command = new SqliteCommand(selectQuery, connection))
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            CustomerID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Email = reader.GetString(2),
                            PasswordHash = reader.GetString(3)
                        });
                    }
                }
            }
            return customers;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT ProductID, Name, Definition, Price, Amount FROM Products";
                using (SqliteCommand command = new SqliteCommand(selectQuery, connection))
                {
                    using(SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                ProductID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Definition = reader.GetString(2),
                                Price = reader.GetDouble(3),
                                Amount = reader.GetInt32(4)
                            });
                        }
                    }
                }
            }
            return products;
        }
    }
}
