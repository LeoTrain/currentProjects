namespace MyClasses
{
    public static partial class FT_Math
    {
        public static double InchToFoot(this double inch) => inch / 12.0;
        public static double InchToYard(this double inch) => inch / 36.0;
        public static double InchToMile(this double inch) => inch / 63360.0;

        public static double FootToInch(this double foot) => foot * 12.0;
        public static double FootToYard(this double foot) => foot / 3.0;
        public static double FootToMile(this double foot) => foot / 5280.0;

        public static double YardToInch(this double yard) => yard * 36.0;
        public static double YardToFoot(this double yard) => yard * 3.0;
        public static double YardToMile(this double yard) => yard / 1760.0;

        public static double MileToInch(this double mile) => mile * 63360.0;
        public static double MileToFoot(this double mile) => mile * 5280.0;
        public static double MileToYard(this double mile) => mile * 1760.0;

        public static double Rounded(this double value, int decimals = 2) => Math.Round(value, decimals);
    }
}
