namespace MyClasses
{
  public class Name
  {
    public string First { get; private set; }
    public string Last { get; private set; }

    public Name()
    {
        First = "No";
        Last = "Name";
    }

    public Name(string firstName, string lastName)
    {
      if (string.IsNullOrEmpty(firstName)) throw new ArgumentException($"Name.First -> {nameof(firstName)} cannot be null or empty.");
      if (string.IsNullOrEmpty(lastName)) throw new ArgumentException($"Name.Last -> {nameof(lastName)} cannot be null or empty.");
      First = firstName;
      Last = lastName;
    }

    public override string ToString() => $"{First} {Last}";

  }
}
