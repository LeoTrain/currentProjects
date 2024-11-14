namespace MyClasses
{
  public class Address
  {
    public string Street { get; private set; }
    public string City { get; private set; }
    public int PostalCode { get; private set; }
    public string Country { get; private set; }

    public Address(string street, string city, int postalCode, string country)
    {
      Street = street;
      City = city;
      PostalCode = postalCode;
      Country = country;
    }

    public override string ToString() => $"{Street}, {City}, {PostalCode}, {Country}";
  }
}
