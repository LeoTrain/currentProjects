namespace MenuFramework
{
    public class Window
    {
        protected double _consoleWindowWidth;
        protected double _consoleWindowHeight;
        protected double _width;
        protected double _height;
        public double Width
        {
            get { return _width; }
            private set
            {
                if (value < 0) throw new ArgumentException("Width must be more than 0.");
                if (value > Console.WindowWidth) throw new ArgumentException($"Width must be less than WindowWidth ({_consoleWindowWidth}).");
                _width = value;
            }
        }
        public double Height
        {
            get { return _height; }
            private set
            {
                if (value < 0) throw new ArgumentException("Height must be more than 0.");
                if (value > Console.WindowHeight) throw new ArgumentException($"Height must be less than WindowHeight ({_consoleWindowHeight}).");
                _height = value;
            }
        }

        public Window()
        {
            _consoleWindowWidth = Console.WindowWidth;
            _consoleWindowHeight = Console.WindowHeight;
            Width = _consoleWindowWidth;
            Height = _consoleWindowHeight;
        }

        public Window(double width, double height)
        {
            _consoleWindowWidth = Console.WindowWidth;
            _consoleWindowHeight = Console.WindowHeight;
            Width = width;
            Height = height;
        }

        public void Show()
        {
            while (true)
            {
                string userInput;
                UserInput(out userInput);
                if (!string.IsNullOrEmpty(userInput))
                    if (userInput == "q") break;

                Display();

                System.Threading.Thread.Sleep(200);
            }
        }

        protected virtual void Display()
        {
            Console.Clear();
            DrawBorders();
        }

        protected virtual void UserInput(out string key)
        {
            key = "";
            if (Console.KeyAvailable)
            {
                var inputKey = Console.ReadKey(intercept: true).Key;
                key = inputKey.ToString().ToLower();
            }
        }

        protected void DrawBorders()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < _width; i++)
                Console.Write("=");
            for (int i = 1; i < _height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("||");
                Console.SetCursorPosition((int)_width-2, i);
                Console.Write("||");
            }
            Console.SetCursorPosition(0, (int)_height);
            for (int i = 0; i < _width; i++)
                Console.Write("=");
        }
    }
}
