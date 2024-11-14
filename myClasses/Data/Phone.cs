namespace MyClasses
{
  public class Phone
  {
    private int _countryCode;
    private int _regionalCode;
    private int _localCode;

    public int CountryCode
    {
      get => _countryCode;
      private set
      {
        if (value.ToString().Length < 1 || value.ToString().Length > 3)
          throw new ArgumentException("Country code must have between 1 and 3 numbers.");
        _countryCode = value;
      }
    }

    public int RegionalCode
    {
      get => _regionalCode;
      private set
      {
        if (value.ToString().Length < 1 || value.ToString().Length > 4)
          throw new ArgumentException("Regional code must have between 1 and 4 numbers.");
        _regionalCode = value;
      }
    }

    public int LocalCode
    {
      get => _localCode;
      private set
      {
        if (value.ToString().Length < 4 || value.ToString().Length > 10)
          throw new ArgumentException("Local code must have between 4 and 10 numbers.");
        _localCode = value;
      }
    }

    public Phone(int countryCode, int regionalCode, int localCode)
    {
      CountryCode = countryCode;
      RegionalCode = regionalCode;
      LocalCode = localCode;
    }

    public override string ToString() => $"+{CountryCode} {RegionalCode} {LocalCode}";
  }
}
