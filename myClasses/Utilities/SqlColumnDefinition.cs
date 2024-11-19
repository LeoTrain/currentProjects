namespace MyClasses
{
    public class SqlColumnDefinition
    {
        public string Name { get; set; }
        public SqlType Type { get; set; }
        public string Constraints { get; set; }

        public SqlColumnDefinition(string name, SqlType type, string constraints = "")
        {
            Name = name;
            Type = type;
            Constraints = constraints;
        }

        public override string ToString()
        {
            return $"{Name} {Type.ToString()} {Constraints}".Trim();
        }
    }
}
