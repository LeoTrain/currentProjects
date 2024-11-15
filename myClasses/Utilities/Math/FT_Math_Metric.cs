namespace MyClasses
{
  public static partial class FT_Math 
  {
    public static class Metric
    {
        public static double MilimeterToCentimeter(double milimeter) => milimeter * 10;
        public static double MilimeterToDecimeter(double milimeter) => milimeter * 100;
        public static double MilimeterToMeter(double milimeter) => milimeter * 1000;
        public static double MilimeterToDecameter(double milimeter) => milimeter * 10000;
        public static double MilimeterToHectometer(double milimeter) => milimeter * 100000;
        public static double MilimeterToKilometer(double milimeter) => milimeter * 1000000;

        public static double CentimeterToMilimeter(double centimeter) => centimeter / 10;
        public static double CentimeterToDecimeter(double centimeter) => centimeter * 10;
        public static double CentimeterToMeter(double centimeter) => centimeter * 100;
        public static double CentimeterToDecameter(double centimeter) => centimeter * 1000;
        public static double CentimeterToHectometer(double centimeter) => centimeter * 10000;
        public static double CentimeterToKilometer(double centimeter) => centimeter * 100000;

        public static double DecimeterToMilimeter(double decimeter) => decimeter / 100;
        public static double DecimeterToCentimerer(double decimeter) => decimeter / 10;
        public static double DecimeterToMeter(double decimeter) => decimeter * 10;
        public static double DecimeterToDecameter(double decimeter) => decimeter * 100;
        public static double DecimeterToHectometer(double decimeter) => decimeter * 1000;
        public static double DecimeterToKilometer(double decimeter) => decimeter * 10000;

        public static double MeterToMilimeter(double meter) => meter / 1000;
        public static double MeterToCentimeter(double meter) => meter / 100;
        public static double MeterToDecimeter(double meter) => meter / 10;
        public static double MeterToDecameter(double meter) => meter * 10;
        public static double MeterToHectometer(double meter) => meter * 100;
        public static double MeterToKilometer(double meter) => meter * 1000;

        public static double DecameterToMilimeter(double decameter) => decameter / 10000;
        public static double DecameterToCentimeter(double decameter) => decameter / 1000;
        public static double DecameterToDecimeter(double decameter) => decameter / 100;
        public static double DecameterToMeter(double decameter) => decameter / 10;
        public static double DecameterToHectometer(double decameter) => decameter * 10;
        public static double DecameterToKilometer(double decameter) => decameter * 100;

        public static double HectometerToMilimeter(double hectometer) => hectometer / 100000;
        public static double HectometerToCentimeter(double hectometer) => hectometer / 10000;
        public static double HectometerToDecimeter(double hectometer) => hectometer / 1000;
        public static double HectometerToMeter(double hectometer) => hectometer / 100;
        public static double HectometerToDecameter(double hectometer) => hectometer / 10;
        public static double HectometerToKilometer(double hectometer) => hectometer * 10;

    }
  }
}
