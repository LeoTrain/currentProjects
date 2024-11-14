namespace MyClasses
{
  public class Dimensions
  {
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }

    public Dimensions(double x, double y, double z)
    {
      if (x < 0) throw new ArgumentException($"X -> {nameof(x)} cannot be under 0.");
      if (y < 0) throw new ArgumentException($"Y -> {nameof(y)} cannot be under 0.");
      if (z < 0) throw new ArgumentException($"Z -> {nameof(z)} cannot be under 0.");
      X = x;
      Y = y;
      Z = z;
    }

    public double GetVolume() => X * Y * Z;
    public double GetSurfaceArea() => 2 * (X * Y + X * Z + Z * Y);
    public bool IsDouble() => X == Y && Y == Z;
    public Dimensions Scale(double factor) => new Dimensions(X * factor, Y * factor, Z * factor);
    public override string ToString() => $"{X}, {Y}, {Z}";
  }
}
