namespace MyClasses
{
  public class OrderItem : Item
  {
    public int Amount { get; private set; }

    public OrderItem(
        int id, string name, string description, int amount = 1
        ) : base(id, name, description)
    {
      if (amount < 0) throw new ArgumentException($"Amount {nameof(amount)} cannot be under 0.");
      Amount = amount;
    }
  }
}
