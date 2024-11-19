namespace MyClasses
{
  internal class Program
  {
    static void Main(string[] args)
    {
      // TestPerson();
      // TestStats();
      // TestNameGenerator();
      // TestTemperatures();
      // TestCipher();
      /*Console.WriteLine($"{FT_Math.Temperatures.FahrenheitToCelsius(0)}");*/
      /*Console.WriteLine($"{FT_Math.Temperatures.FahrenheitToCelsius(100)}");*/
      /*TestDBManager();*/
      TestAge();
    }
    
    static void TestAge()
    {
      Age myAge = new Age(new DateTime(2001, 10, 25));
      Console.WriteLine(myAge);
      int ageInMonths = myAge.LifeTimeInMonths();
      int ageInDays = myAge.LifeTimeInDays();
      int ageInHours = myAge.LifeTimeInHours();
      int ageInMinutes = myAge.LifeTimeInMinutes();
      int ageInSeconds = myAge.LifeTimeInSeconds();
      Console.WriteLine(ageInMonths);
      Console.WriteLine(ageInDays);
      Console.WriteLine(ageInHours);
      Console.WriteLine(ageInMinutes);
      Console.WriteLine(ageInSeconds);
    }

    static void TestDBManager()
    {
      string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "InventoryDB.db");
      DatabaseManagerSQLite manager = new DatabaseManagerSQLite(dbPath);
      List<SqlColumnDefinition> columns = new List<SqlColumnDefinition>
      {
          new SqlColumnDefinition("ID", SqlType.INTEGER, "PRIMARY KEY AUTOINCREMENT")
      };
      manager.Connect();
      manager.CreateTable("Products", columns);
      manager.Close();
      manager.Connect();
      Product product = new Product();
      Dictionary<string, object> data = new Dictionary<string, object>
      {
          { "Name", product.Name },
          { "Description", product.Description },
          { "Price", product.Price.Value },
          { "StockQuantity", product.Stock.StockQuantity },
      };
      manager.Connect();
      manager.InsertData("Products", data);
      manager.Close();
    }

    static void TestCipher()
    {
      string cesar = "Leonardo";
      string cesarEncrypt = Cipher.CesarEncrypt(cesar);
      Console.WriteLine($"{cesar} -> {cesarEncrypt}");
      Console.WriteLine($"{cesarEncrypt} -> {Cipher.CesarDecrypt(cesarEncrypt)}");
    }

    static void TestStats()
    {
      // double[] array = [1.2, 18.23, 6.18, 6.17, 15.3];
      // double[] sortedArray = Sorter.Array(array);
      // foreach (double nbr in sortedArray)
      //   Console.WriteLine(nbr);
      double[] array = [1.2, 18.23, 6.18, 6.17, 15.3, 6.18, 1.2, 18.23, 18.23];
      Console.WriteLine($"{FT_Math.Statistics.Mean(array)}");
      Console.WriteLine($"{FT_Math.Statistics.Median(array)}");
      foreach (double nbr in FT_Math.Statistics.Mode(array))
        Console.WriteLine(nbr);
    }

    static void TestTemperatures()
    {
      double tolerance = 0.01;
      Console.WriteLine(Math.Abs(FT_Math.Temperatures.CelsiusToFahrenheit(0) - 32) < tolerance ? "Pass" : "Fail"); // 0°C -> 32°F
      Console.WriteLine(Math.Abs(FT_Math.Temperatures.CelsiusToFahrenheit(100) - 212) < tolerance ? "Pass" : "Fail"); // 100°C -> 212°F

      Console.WriteLine(Math.Abs(FT_Math.Temperatures.CelsiusToKelvin(0) - 273.15) < tolerance ? "Pass" : "Fail"); // 0°C -> 273.15 K
      Console.WriteLine(Math.Abs(FT_Math.Temperatures.CelsiusToKelvin(-273.15) - 0) < tolerance ? "Pass" : "Fail"); // -273.15°C -> 0 K

      Console.WriteLine(Math.Abs(FT_Math.Temperatures.CelsiusToRankine(0) - 491.67) < tolerance ? "Pass" : "Fail"); // 0°C -> 491.67 °R
      Console.WriteLine(Math.Abs(FT_Math.Temperatures.CelsiusToRankine(100) - 671.67) < tolerance ? "Pass" : "Fail"); // 100°C -> 671.67 °R

      Console.WriteLine(Math.Abs(FT_Math.Temperatures.FahrenheitToCelsius(32) - 0) < tolerance ? "Pass" : "Fail"); // 32°F -> 0°C
      Console.WriteLine(Math.Abs(FT_Math.Temperatures.FahrenheitToCelsius(212) - 100) < tolerance ? "Pass" : "Fail"); // 212°F -> 100°C

      Console.WriteLine(Math.Abs(FT_Math.Temperatures.KelvinToCelsius(273.15) - 0) < tolerance ? "Pass" : "Fail"); // 273.15 K -> 0°C
      Console.WriteLine(Math.Abs(FT_Math.Temperatures.KelvinToCelsius(0) - -273.15) < tolerance ? "Pass" : "Fail"); // 0 K -> -273.15°C

      Console.WriteLine(Math.Abs(FT_Math.Temperatures.RankineToCelsius(491.67) - 0) < tolerance ? "Pass" : "Fail"); // 491.67 °R -> 0°C
      Console.WriteLine(Math.Abs(FT_Math.Temperatures.RankineToCelsius(671.67) - 100) < tolerance ? "Pass" : "Fail"); // 671.67 °R -> 100°C
    }

    static void TestNameGenerator()
    {
      Console.WriteLine($"{NameGenerator.PhoneticStrangeNames()}");
    }

    static void TestPerson()
    {
      // Person me = new Person("Leonardo", "Bertonasco", GenderType.Male, new DateTime(2001, 10, 25), new ContactInfo(new Email("leonardo@gmail.com"), "+32456783312"));
      //
      // Console.WriteLine(me.ToString());
    }
  }
}
