using Microsoft.Data.Sqlite;

namespace MyClasses
{
    public class DatabaseManagerSQLite
    {
        protected SqliteConnection connection;

        public DatabaseManagerSQLite(string dbName)
        {
            connection = new SqliteConnection($"Data Source={dbName};");
        }

        public void Connect()
        {
            connection.Open();
        }

        public void CreateTable(string tableName, List<SqlColumnDefinition> columns)
        {
            string columnsDef = string.Join(", ", columns.Select(col => col.ToString()));
            string query = $"CREATE TABLE IF NOT EXISTS {tableName} ({columnsDef})";

            using (var command = new SqliteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void InsertData(string tableName, Dictionary<string, object> data)
        {
            string columns = string.Join(", ", data.Keys);
            string placeholders = string.Join(", ", data.Keys.Select(key => $"@{key}"));
            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({placeholders})";

            using (var command = new SqliteCommand(query, connection))
            {
                foreach (var kvp in data)
                    command.Parameters.AddWithValue($"@{kvp.Key}", kvp.Value);
                command.ExecuteNonQuery();
            }
        }

        public string[] GetDataFromColumn(string tableName, string columnName)
        {
            List<string> results = new List<string>();
            string query = $"SELECT {columnName} FROM {tableName}";
            SqliteCommand command = new SqliteCommand(query, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                    results.Add(reader[columnName].ToString() ?? "NULL");
            }
            return results.ToArray();
        }

        public void Close()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
    }
}
