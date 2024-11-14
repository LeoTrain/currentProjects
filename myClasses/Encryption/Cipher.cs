namespace MyClasses
{
  public static class Cipher
  {
    private const int shift = 12;

    public static string CesarEncrypt(string text)
    {
      string result = "";
      foreach (char cr in text)
      {
        if (char.IsUpper(cr))
          result += (char)((cr + shift - 65) % 26 + 65);
        else if (char.IsLower(cr))
          result += (char)((cr + shift - 97) % 26 + 97);
        else
          result += cr;
      }
      return result;
    }

    public static string CesarDecrypt(string text)
    {
      string result = "";
      foreach (char cr in text)
      {
        if (char.IsUpper(cr))
          result += (char)(((cr - shift - 65 + 26) % 26) + 65);
        else if (char.IsLower(cr))
          result += (char)(((cr - shift - 97 + 26) % 26) + 97);
        else
          result += cr;
      }
      return result;
    }
  }
}
