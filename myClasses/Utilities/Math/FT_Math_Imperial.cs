namespace MyClasses
{
  public partial class FT_Math
  {
    public static class Imperial
    {
      public static double InchToCentimeter(double inch) => inch / 2.54;
      public static double FootToCentimeter(double foot) => foot / 30.48;
      public static double YardToCentimeter(double yard) => yard / 91.44;
      public static double MileToKilometer(double mile) => mile / 1.609;
      public static double OunceToGramm(double ounce) => ounce;
      public static double PoundToGramm(double pound) => pound;
      public static double StoneToKilogramm(double stone) => stone;
      public static double PintToMilliliter(double pin) => pin;
      public static double GallonToLiter(double gallon) => gallon;
    }
  }
}
