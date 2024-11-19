using Figgle;

namespace MenuFramework
{
   public class MenuWindow : Window
   {
        private string _title = "Menu";
        protected Dictionary<string, Action> _options = new Dictionary<string, Action>();
        protected int _selectedOption = 0;

        public string Title
        {
            get { return _title; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Title cannot be null or empty.");
                if (value.Length >= _width)
                    throw new ArgumentException("Title must be smaller than Width.");;

                _title = value;
            }
        }
        public Dictionary<string, Action> Options
        {
            get { return _options; }
            private set
            {
                _options = value;
            }
        }

        public MenuWindow() : this(80, 20, "Menu", new Dictionary<string, Action>()) {}
        public MenuWindow(double width, double height) : this(width, height, "Menu", new Dictionary<string, Action>()) {}
        public MenuWindow(string title) : this(Console.WindowWidth, Console.WindowHeight, title, new Dictionary<string, Action>()) {}
        public MenuWindow(Dictionary<string, Action> options) : this(Console.WindowWidth, Console.WindowHeight, "Menu", options) {}
        public MenuWindow(double width, double height, string title) : this(width, height, title, new Dictionary<string, Action>()) {}
        public MenuWindow(double width, double height, Dictionary<string, Action> options) : this(width, height, "Menu", options) {}
        public MenuWindow(double width, double height, string title, Dictionary<string, Action> options) :base(width, height)
        {
           Title = title;
           Options = options;
        }

        protected override void Display()
        {
            base.Display();
            DisplayTitle();
            DisplayOptions();
        }

        protected void DisplayTitle()
        {
            string asciiTitle = FiggleFonts.Standard.Render(_title);
            string[] lines = asciiTitle.Split('\n');

            int startX = ((int)_consoleWindowWidth / 2) - (lines[0].Length / 2);
            int startY = 2;

            for (int i = 0; i < lines.Length; i++)
            {
                Console.SetCursorPosition(startX, startY + i);
                Console.WriteLine(lines[i]);
            }            
        }

        protected void DisplayOptions()
        {
            int yStart = ((int)_height - _options.Count()) / 2;
            int xStart;
            List<string> optionKeys = _options.Keys.ToList();
            for (int i = 0; i < _options.Count(); i++) 
            {
                string opt = optionKeys[i];
                xStart = ((int)_width - opt.Length) / 2;
                Console.SetCursorPosition(xStart, yStart++);
                if (i == _selectedOption)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(opt);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        protected override void UserInput(out string key)
        {
            base.UserInput(out key);
            if (!string.IsNullOrEmpty(key))
            {
                if (key == "w" && _selectedOption > 0)
                    _selectedOption--;
                else if (key == "s" && _selectedOption < _options.Count() - 1)
                    _selectedOption++;
                else if (key == "enter")
                {
                    string selectedOption = _options.Keys.ToList()[_selectedOption];
                    _options[selectedOption]?.Invoke();
                }
            }
        }
   }
}
