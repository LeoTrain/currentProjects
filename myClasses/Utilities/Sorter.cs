namespace MyClasses
{
  public static class Sorter
  {
    public static double[] Array(double[] array)
    {
      for (int i = 0; i < array.Length - 1; i++)
      {
        if (array[i] > array[i + 1])
        {
          double swap = array[i];
          array[i] = array[i + 1];
          array[i + 1] = swap;
          i = -1;
        }
      }
      return array;
    }
  }
}
