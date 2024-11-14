namespace MyClasses
{
  public class Pricing
  {
    public decimal Value { get; private set; }
    public List<decimal> PriceHistory { get; private set; }

    public Pricing(decimal initialValue)
    {
      if (initialValue < 0) throw new ArgumentException($"Initial Price cannot be under 0.00");
      Value = initialValue;
      PriceHistory = new List<decimal> { initialValue };
    }

    public void UpdatePrice(decimal newValue)
    {
      if (newValue < 0) throw new ArgumentException($"New Price cannot be under 0.00");
      PriceHistory.Add(newValue);
      Value = newValue;
    }
  }
}
