namespace MenuFramework
{
  class Program
  {
      static void Main()
      {
          MenuWindow window = new MenuWindow(new List<string> {"abc", "def", "ghi"});
          window.Show();
      }
  }
}
