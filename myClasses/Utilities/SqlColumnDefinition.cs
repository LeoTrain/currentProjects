namespace MyClasses
{
    public class ColumnDefinition
    {
        public string Name { get; set; }
        public SqlType Type { get; set; }
        public string Constraints { get; set; }

        public ColumnDefinition(string name, SqlType type, string constraints = "")
        {
            Name = name;
            Type = type;
            Constraints = constraints;
        }
    }
}
