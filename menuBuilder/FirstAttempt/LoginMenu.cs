namespace MenuBuilder
{
  public class LoginMenu : Menu
  {
    public string Username { get; private set; }
    public string Password { get; private set; }

    public LoginMenu(string title) : base(title)
    {
      Username = "";
      Password = "";
    }

    public new bool Display()
    {
      DrawBorder();
      DrawTitle();
      DrawLoginFields();
      return HandleLoginInput();
    }

    public void Reset()
    {
      Username = "";
      Password = "";
    }

    private void DrawLoginFields()
    {
      Console.SetCursorPosition(_screenCenter.Item1 - 10, _screenCenter.Item2 - 2);
      Console.Write("Username: " + Username);

      Console.SetCursorPosition(_screenCenter.Item1 - 10, _screenCenter.Item2);
      Console.Write("Password: " + new string('*', Password.Length));
    }

    private bool HandleLoginInput()
    {
      bool isPassword = false;
      bool inputChanged = true;
      ConsoleKeyInfo keyInfo;
      
      do
      {
        if (inputChanged)
        {
          DrawLoginFields();
          inputChanged = false;
        }

        keyInfo = Console.ReadKey(true);

        if (keyInfo.Key == ConsoleKey.Backspace)
        {
          if (isPassword && Password.Length > 0)
          {
            Password = Password[..^1];
            inputChanged = true;
          }
          else if (!isPassword && Username.Length > 0)
          {
            Username = Username[..^1];
            inputChanged = true;
          }
        }
        else if (keyInfo.Key == ConsoleKey.Enter)
        {
          if (!isPassword)
          {
            isPassword = true;
            inputChanged = true;
          }
          else
          {
            return true;
          }
        }
        else if (keyInfo.Key != ConsoleKey.Escape)
        {
            char keyChar = keyInfo.KeyChar;
            if (!char.IsControl(keyChar))
            {
              if (isPassword)
                Password += keyChar;
              else
                Username += keyChar;
              inputChanged = true;
            }
        }
      } while (keyInfo.Key != ConsoleKey.Escape);
      return false;
    }
  }
}
