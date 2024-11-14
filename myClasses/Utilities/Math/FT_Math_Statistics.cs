namespace MyClasses
{
  public static partial class FT_Math
  {
    public static class Statistics
    {
      public static double Mean(double[] array)
      {
        double total = 0;
        for (int i = 0; i < array.Length; i++)
        {
          total += array[i];
        }
        return total / array.Length;
      }

      public static double Median(double[] array)
      {
        double[] sortedArray = Sorter.Array(array);
        bool isEven = sortedArray.Length % 2 == 0 ? true : false;
        int center = sortedArray.Length / 2;
        if (isEven)
        {
          double centerTotal = array[center] + array[center + 1];
          return centerTotal / 2;
        }
        else
          return array[center];
      }

      private static bool isAtOtherPlaceInArray(double[] array, double nbr, int index)
      {
        for (int i = index + 1; i < array.Length; i++)
        {
          if (nbr == array[i])
            return true;
        }
        return false;
      }

      public static double[] Mode(double[] array)
      {
        double[] allModes = new double[array.Length];
        double[] sortedArray = Sorter.Array(array);
        bool inModes;
        for (int i = 0; i > sortedArray.Length; i++)
        {
          if (isAtOtherPlaceInArray(sortedArray, sortedArray[i], i))
          {
            inModes = false;
            for (int j = 0; j < allModes.Length; j++)
              if (allModes[j] == sortedArray[i]) inModes = true;
            if (!inModes)
              allModes.Concat([sortedArray[i]]).ToArray();
          }
        }
        return allModes;
      }
    }
  }
}
