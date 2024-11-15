# FT_Math

## Description

**FT_Math** is a C# class divided into several static modules that perform various mathematical operations, conversions, and statistical calculations. Each module serves a specific purpose, such as converting between metric and imperial units, performing statistical calculations, or temperature conversions.

## Main Features

- **Imperial Conversions**: Convert units like inches, feet, yards, and miles to metric units.
- **Metric Conversions**: Transform between different units within the metric system.
- **Statistics**: Calculate the mean, median, and mode of a data array.
- **Temperature Conversions**: Switch between Celsius, Fahrenheit, Kelvin, and Rankine.

## Prerequisites

- C# (.NET 6 or higher)
- Development environment such as Visual Studio or Neovim with C# support

## Installation

1. Clone the repository containing the FT_Math class.
2. Add the files to your project.
3. Compile with a C# compatible environment.

## Usage

### Basic Code Example

```csharp
using MyClasses;

class Program
{
    static void Main(string[] args)
    {
        double inches = 12;
        double centimeters = inches.InchToCentimeter();
        Console.WriteLine($"{inches} inches = {centimeters} cm");

        double milimeters = 1000;
        double centi = milimeters.MilimeterToCentimeter();
        Console.WriteLine($"{milimeters} mm = {centi} cm");

        double[] data = { 1, 2, 2, 3, 4 };
        double mean = FT_Math.Statistics.Mean(data);
        Console.WriteLine($"The mean is {mean}");
    }
}
```

### Key Methods Description

#### Module: `Imperial`
- **`InchToCentimeter(this double inch)`**: Converts inches to centimeters.
- **`MileToKilometer(this double mile)`**: Converts miles to kilometers.

#### Module: `Temperatures`
- **`CelsiusToFahrenheit(double input)`**: Converts Celsius to Fahrenheit.
- **`KelvinToCelsius(double input)`**: Converts Kelvin to Celsius.

> **Note**: Methods in both the `Metric` and `Imperial` modules are implemented as extension methods and must be called using a `double` instance, such as `myValue.MilimeterToCentimeter()` or `myValue.InchToCentimeter()`.

## Contribution

1. Fork the project
2. Create a branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request


