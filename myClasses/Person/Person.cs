namespace MyClasses
{
  public class Person : LivingBeing
  {
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public ContactInfo ContactInfo { get; private set; }

    public Person(string firstName, string lastName, GenderType gender, DateTime birthDate, ContactInfo contactInfo)
      : base(birthDate, gender)
    {
      if (string.IsNullOrWhiteSpace(firstName))
        throw new ArgumentException("firstName cannot be null or empty.", nameof(firstName));
      if (string.IsNullOrWhiteSpace(lastName))
        throw new ArgumentException("lastName cannot be null or empty.", nameof(lastName));
      if (!this.IsBirthDateValid(birthDate))
        throw new ArgumentException("birtDate must be over 10 and under 110");

      FirstName = firstName;
      LastName = lastName;
      ContactInfo = contactInfo;
    }

    public string FullName
    {
      get { return $"{FirstName} {LastName}"; }
    }

    private bool IsBirthDateValid(DateTime birthDate)
    {
      int age = DateTime.Now.Year - birthDate.Year;

      if (birthDate.Date > DateTime.Now.AddYears(-age))
      {
        age--;
      }
      return age <= 110 && age > 10;
    }

    public override string ToString() => $"{FullName} {Gender}, Age: {Age}, BirthDate: {DateOfBirth.ToShortDateString()}, {ContactInfo.ToString()}";
  }
}
