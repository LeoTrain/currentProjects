namespace MyClasses
{
  public class Customer : Person
  {
    public Customer(string firstName, string lastName, GenderType gender, DateTime birthDate, ContactInfo contactInfo)
      : base(firstName, lastName, gender, birthDate, contactInfo)
    {

    }
  }
}
