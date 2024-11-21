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

    public Email()
    {
        LocalPart = "noemail";
        DomainName = "nomail";
        TopLevelDomain = "no";
    }

    public Email(string localPart, string domainName, string topLevelDomain)
    {
      LocalPart = localPart;
      DomainName = domainName;
      TopLevelDomain = topLevelDomain;
    }

    public override string ToString() => $"{LocalPart}@{DomainName}.{TopLevelDomain}";

    public static Email FromString(string emailString)
    {
        string local;
        string domain;
        string tld;

        string[] parts = emailString.Split("@");
        if (parts.Length != 2)
            throw new ArgumentException("Invalid email format.");

        local = parts[0];
        string[] domains = parts[1].Split(".");
        if (domains.Length != 2)
            throw new ArgumentException("Invalid email format.");
        domain = domains[0];
        tld = domains[1];

        return new Email(local, domain, tld);
    }
      
  }
}
