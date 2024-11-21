namespace MyClasses
{
  public class SupplierInfo
  {
    public Name Name { get; private set; }
    public ContactInfo Contact { get; private set; }

    public SupplierInfo()
    {
        Name = new Name();
        Contact = new ContactInfo();
    }

    public SupplierInfo(Name name, ContactInfo contact)
    {
      Name = name;
      Contact = contact;
    }
  }
}
