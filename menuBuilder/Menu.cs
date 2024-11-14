using Figgle;

namespace MenuBuilder
{
  public class Menu
  {
    protected List<MenuOption> _options;
    protected string _title;
    protected int _width;
    protected int _height;
    protected int _selectedIndex;
    protected (int, int) _screenCenter;
    protected bool _topScoreToDisplay;
    protected int _topScore;

    public Menu(string title)
    {
      _options = new List<MenuOption>();
      _title = title;
      _width = Console.WindowWidth;
      _height = Console.WindowHeight;
      _screenCenter = (_width / 2, _height / 2);
      _selectedIndex = 0;
      _topScoreToDisplay = false;
    }

    public void AddOption(string label, Action action)
    {
      _options.Add(new MenuOption(label, action));
    }

    public void Display()
    {
      DrawBorder();
      DrawTitle();
      DrawMenu();
      HandleInput();
    }
    
    public void AddTopScore(int topScore)
    {
      _topScoreToDisplay = true;
      _topScore = topScore;
    }

    public static void DrawBox(int width, int height, int xStart, int yStart)
    {
      Console.SetCursorPosition(xStart, yStart);
      Console.Write("╔");
      for (int i = 1; i < width; i++)
      {
        Console.SetCursorPosition(xStart + i, yStart);
        Console.Write("=");
      }
      Console.SetCursorPosition(xStart + width, yStart);
      Console.Write("╗");

      for (int i = 1; i < height - 1; i++)
      {
        Console.SetCursorPosition(xStart, yStart + i);
        Console.Write("║");
        Console.SetCursorPosition(xStart + width, yStart + i);
        Console.Write("║");
      }
      Console.SetCursorPosition(xStart, yStart + height - 1);
      Console.Write("╚");
      for (int i = 1; i < width; i++)
      {
        Console.SetCursorPosition(xStart + i, yStart + height - 1);
        Console.Write("=");
      }
        Console.SetCursorPosition(xStart + width, yStart + height - 1);
        Console.Write("╝");
    }

    protected void HandleInput()
    {
      ConsoleKey key;
      do
      {
          key = Console.ReadKey(true).Key;
          switch (key)
          {
              case ConsoleKey.W:
                  _selectedIndex = (_selectedIndex == 0) ? _options.Count - 1 : _selectedIndex - 1;
                  break;
              case ConsoleKey.S:
                  _selectedIndex = (_selectedIndex == _options.Count - 1) ? 0 : _selectedIndex + 1;
                  break;
              case ConsoleKey.Enter:
                  _options[_selectedIndex].Execute();
                  return;
          }
          Display();
      } while (key != ConsoleKey.Escape);
    }

    protected void DrawBorder()
    {
      Console.Clear();
      for (int i = 0; i < _width; i++)
      {
        Console.SetCursorPosition(i, 0);
        Console.Write("-");
        Console.SetCursorPosition(i, _height - 1);
        Console.Write("-");
      }
      for (int i = 0; i < _height; i++)
      {
        Console.SetCursorPosition(0, i);
        Console.Write("|");
        Console.SetCursorPosition(_width - 1, i);
        Console.Write("|");
      }
    }

    protected void DrawTitle()
    {
      string asciiTitle = FiggleFonts.Standard.Render(_title);
      string[] lines = asciiTitle.Split('\n');

      int startX = _screenCenter.Item1 - (lines[0].Length / 2);
      int startY = 2;

      for (int i = 0; i < lines.Length; i++)
      {
          Console.SetCursorPosition(startX, startY + i);
          Console.WriteLine(lines[i]);
      }
    }

    private void DrawTopScore()
    {
      string scoreString = $"TOP SCORE {_topScore}";
      int xStart = _width - scoreString.Length - 17;
      int yStart = 10;
      DrawBox(scoreString.Length + 2, 3, xStart, yStart);
      Console.SetCursorPosition(xStart + 2, yStart + 1);
      Console.WriteLine(scoreString);
    }

    private string GetLongestStringFromOptions()
    {
      string longestString = _options
          .Select(option => option.Label)
          .OrderByDescending(label => label.Length)
          .FirstOrDefault() ?? "";
      return longestString;
    }

    private void DrawMenuOptions(int xStart, int yStart)
    {
      for (int i = 0; i < _options.Count; i++)
      {
        Console.SetCursorPosition(xStart + 2, yStart + i + 1);
        if (i == _selectedIndex)
        {
          Console.BackgroundColor = ConsoleColor.Gray;
          Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        Console.WriteLine(_options[i].Label);
        Console.ResetColor();
      }
    }

    private void DrawMenu()
    {
      string longestString = GetLongestStringFromOptions();
      int xStart = _screenCenter.Item1 - (longestString.Length / 2) - 3; 
      int yStart = _screenCenter.Item2 - (_options.Count / 2) - 3;
      DrawMenuOptions(xStart, yStart);
      DrawBox(longestString.Length + 4, _options.Count + 2, xStart, yStart);
      if (_topScoreToDisplay)
        DrawTopScore();
    }

  }
}
