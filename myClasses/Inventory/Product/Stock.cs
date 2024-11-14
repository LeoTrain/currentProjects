namespace MyClasses
{
  public class Stock
  {
    public int StockQuantity { get; private set; }
    public int ReorderLevel { get; private set; }
    public int ReoderQuantity { get; private set; }

    public Stock(int stockQuantity, int reorderLevel = 0, int reoderQuantity = 0)
    {
      if (stockQuantity < 0) throw new ArgumentException("Stock Quantity cannot be negative.");
      if (reorderLevel < 0) throw new ArgumentException("Reorder Level cannot be negative.");
      if (reoderQuantity < 0) throw new ArgumentException("Reorder Quantity cannot be negative.");
      StockQuantity = stockQuantity;
      ReorderLevel = reorderLevel;
      ReoderQuantity = reoderQuantity;
    }

    public bool NeedRestocking() => StockQuantity <= ReoderQuantity;
  }
}
