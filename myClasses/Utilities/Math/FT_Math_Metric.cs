namespace MyClasses
{
  public static partial class FT_Math 
  {
    public static class Metric
    {
      public static double CentimeterToDecimeter(double centimeter) => centimeter * 10;
      public static double CentimeterToMeter(double centimeter) => centimeter * 100;
      public static double CentimeterToDecameter(double centimeter) => centimeter * 1000;
      public static double CentimeterToHectoMeter(double centimeter) => centimeter * 10000;
      public static double CentimeterToKilometer(double centimeter) => centimeter * 100000;
    }
  }
}
