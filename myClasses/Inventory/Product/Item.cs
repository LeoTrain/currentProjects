namespace MyClasses
{
  public abstract class Item
  {
    public int ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public Item(int id, string name, string description)
    {
      if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name cannot be null or empty.");
      if (string.IsNullOrEmpty(description)) throw new ArgumentException("Description cannot be null or empty.");
      ID = id;
      Name = name;
      Description = description;
    }
  }
}
