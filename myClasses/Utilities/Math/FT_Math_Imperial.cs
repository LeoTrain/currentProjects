namespace MyClasses
{
  public partial class FT_Math
  {
      public static double InchToCentimeter(this double inch) => inch / 2.54;
      public static double FootToCentimeter(this double foot) => foot / 30.48;
      public static double YardToCentimeter(this double yard) => yard / 91.44;
      public static double MileToKilometer(this double mile) => mile / 1.609;
      public static double OunceToGramm(this double ounce) => ounce;
      public static double PoundToGramm(this double pound) => pound;
      public static double StoneToKilogramm(this double stone) => stone;
      public static double PintToMilliliter(this double pin) => pin;
      public static double GallonToLiter(this double gallon) => gallon;
  }
}
