namespace MyClasses
{
  public class ContactInfo
  {
    public Email Email { get; private set; }
    public Phone Phone { get; private set; }

    public ContactInfo()
    {
        Email = new Email();
        Phone = new Phone();
    }

    public ContactInfo(Email email, Phone phone)
    {
      Email = email;
      Phone = phone;
    }

    public override string ToString() => $"Email: {Email}, Phone: {Phone}";
  }
}
