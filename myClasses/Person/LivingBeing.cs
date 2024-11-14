namespace MyClasses
{
  public abstract class LivingBeing
  {
    public DateTime DateOfBirth { get; private set; }
    public GenderType Gender { get; private set; }

    public LivingBeing(DateTime dateOfBirth, GenderType gender)
    {
      DateOfBirth = dateOfBirth;
      Gender = gender;
    }

    public int Age
    {
      get
      {
        int age = DateTime.Now.Year - DateOfBirth.Year;
        if (DateOfBirth.Date > DateTime.Now.AddYears(-age)) age--;
        return age;
      }
    }

    public override string ToString() => $"{Gender}, Born {DateOfBirth}, Age {Age}";
  }
}
