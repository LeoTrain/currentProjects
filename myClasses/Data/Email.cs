namespace MyClasses
{
  public class Email
  {
    private string _localPart = string.Empty;
    private string _domainName = string.Empty;
    private string _topLevelDomain = string.Empty;

    public string LocalPart
    {
      get => _localPart;
      private set
      {
        if (string.IsNullOrEmpty(value))
          throw new ArgumentException($"LocalPart {nameof(value)} cannot be null or empty.");
        _localPart = value;
      }
    }

    public string DomainName
    {
      get => _domainName;
      private set
      {
        if (string.IsNullOrEmpty(value))
          throw new ArgumentException($"DomainName {nameof(value)} cannot be null or empty.");
        _domainName = value;
      }
    }

    public string TopLevelDomain
    {
      get => _topLevelDomain;
      private set
      {
        if (string.IsNullOrEmpty(value))
          throw new ArgumentException($"TopLevelDomain {nameof(value)} cannot be null or empty.");
        _topLevelDomain = value;
      }
    }

    public Email(string localPart, string domainName, string topLevelDomain)
    {
      LocalPart = localPart;
      DomainName = domainName;
      TopLevelDomain = topLevelDomain;
    }
  }
}
