namespace MyClasses
{
  public static class NameGenerator
  {
    private static string GetRandomPatterns()
    {
      Random random = new Random();
      int length = random.Next(5, 8);
      string syllables = "CV";
      string pattern = "";
      for (int i = 0; i < length; i++)
        pattern += syllables[random.Next(syllables.Length)];
      return pattern;
    }

    public static string PhoneticStrangeNames()
    {
      List<string> consonants = new List<string> { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "r", "s", "t", "v", "w", "z" };
      List<string> syllables = new List<string> { "ka", "lo", "mi", "ra", "ti", "zo", "fi", "sa", "ne", "mo" };
      Random random = new Random();
      string name = "";

      string pattern = GetRandomPatterns();
      string newChar;

      for (int i = 0; i < pattern.Length; i++)
      {
        if (pattern[i] == 'C')
          newChar = consonants[random.Next(consonants.Count)];
        else
          newChar = syllables[random.Next(syllables.Count)];
        name += newChar;
      }
      return StringExtensions.FirstCharToUpper(name.ToString());
    }
  }
}
