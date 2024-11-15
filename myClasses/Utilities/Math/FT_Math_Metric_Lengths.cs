namespace MyClasses
{
    public static partial class Metric
    {
        public static double MilimeterToCentimeter(this double milimeter) => milimeter * 10;
        public static double MilimeterToDecimeter(this double milimeter) => milimeter * 100;
        public static double MilimeterToMeter(this double milimeter) => milimeter * 1000;
        public static double MilimeterToDecameter(this double milimeter) => milimeter * 10000;
        public static double MilimeterToHectometer(this double milimeter) => milimeter * 100000;
        public static double MilimeterToKilometer(this double milimeter) => milimeter * 1000000;

        public static double CentimeterToMilimeter(this double centimeter) => centimeter / 10;
        public static double CentimeterToDecimeter(this double centimeter) => centimeter * 10;
        public static double CentimeterToMeter(this double centimeter) => centimeter * 100;
        public static double CentimeterToDecameter(this double centimeter) => centimeter * 1000;
        public static double CentimeterToHectometer(this double centimeter) => centimeter * 10000;
        public static double CentimeterToKilometer(this double centimeter) => centimeter * 100000;

        public static double DecimeterToMilimeter(this double decimeter) => decimeter / 100;
        public static double DecimeterToCentimerer(this double decimeter) => decimeter / 10;
        public static double DecimeterToMeter(this double decimeter) => decimeter * 10;
        public static double DecimeterToDecameter(this double decimeter) => decimeter * 100;
        public static double DecimeterToHectometer(this double decimeter) => decimeter * 1000;
        public static double DecimeterToKilometer(this double decimeter) => decimeter * 10000;

        public static double MeterToMilimeter(this double meter) => meter / 1000;
        public static double MeterToCentimeter(this double meter) => meter / 100;
        public static double MeterToDecimeter(this double meter) => meter / 10;
        public static double MeterToDecameter(this double meter) => meter * 10;
        public static double MeterToHectometer(this double meter) => meter * 100;
        public static double MeterToKilometer(this double meter) => meter * 1000;

        public static double DecameterToMilimeter(this double decameter) => decameter / 10000;
        public static double DecameterToCentimeter(this double decameter) => decameter / 1000;
        public static double DecameterToDecimeter(this double decameter) => decameter / 100;
        public static double DecameterToMeter(this double decameter) => decameter / 10;
        public static double DecameterToHectometer(this double decameter) => decameter * 10;
        public static double DecameterToKilometer(this double decameter) => decameter * 100;

        public static double HectometerToMilimeter(this double hectometer) => hectometer / 100000;
        public static double HectometerToCentimeter(this double hectometer) => hectometer / 10000;
        public static double HectometerToDecimeter(this double hectometer) => hectometer / 1000;
        public static double HectometerToMeter(this double hectometer) => hectometer / 100;
        public static double HectometerToDecameter(this double hectometer) => hectometer / 10;
        public static double HectometerToKilometer(this double hectometer) => hectometer * 10;

        public static double Rounded(this double value, int decimals = 2) => Math.Round(value, decimals);
    }
}
