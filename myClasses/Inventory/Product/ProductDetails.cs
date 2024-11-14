namespace MyClasses
{
  public class ProductDetails
  {
    public double Weight { get; private set; }
    public Dimensions Dimension { get; private set; }

    public ProductDetails(double weight, Dimensions dimensions)
    {
      if (weight < 0) throw new ArgumentException($"Weight {nameof(weight)} cannot be under 0.");
      Weight = weight;
      Dimension = dimensions;
    }
  }
}
