namespace MyClasses
{
  public static partial class FT_Math
  {
    public static class Temperatures
    {
      public static double CelsiusToFahrenheit(double input) { return input * 9 / 5 + 32; }
      public static double CelsiusToKelvin(double input) { return input + 273.15; }
      public static double CelsiusToRankine(double input) { return (input + 273.15) * 9 / 5; }
      public static double FahrenheitToCelsius(double input) { return (input - 32) * 5 / 9; }
      public static double KelvinToCelsius(double input) { return input - 273.15; }
      public static double RankineToCelsius(double input) { return (input - 491.67) * 5 / 9; }
    }
  }
}
