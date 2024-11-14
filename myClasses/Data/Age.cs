namespace MyClasses
{
  public class Age
  {
    private DateTime _birthDate;

    public DateTime BirthDate
    {
      get { return _birthDate; }
      private set 
      {
        _birthDate = value; 
      }
    }

    public Age(DateTime birthDate)
    {
      BirthDate = birthDate;
    }

    public int TodaysAge
    {
      get
      {
        int age = DateTime.Today.Year - _birthDate.Year;
        if (BirthDate.Date > DateTime.Today.AddYears(-age)) age--;
        return age;
      }
      private set { TodaysAge = value; }
    }

    public int LifeTimeInMonths() => TodaysAge * 12 + (DateTime.Today.Month - BirthDate.Month);
    public int LifeTimeInDays() => (DateTime.Today - BirthDate).Days;
    public int LifeTimeInHours() => (int)(DateTime.Now - BirthDate).TotalHours;
    public int LifeTimeInMinutes() => LifeTimeInHours() * 60;
    public int LifeTimeInSeconds() => LifeTimeInMinutes() * 60;
 
    public override string ToString() => $"{TodaysAge}";

  }
}
