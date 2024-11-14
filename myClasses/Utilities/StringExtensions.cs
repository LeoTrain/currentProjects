namespace MyClasses
{
  public static class StringExtensions
  {
    public static string FirstCharToUpper(this string input) =>
      input switch
      {
        null => throw new ArgumentException(nameof(input)),
        "" => throw new ArgumentException($"{nameof(input)} cannot be empty."),
        _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
      };
  }
}
