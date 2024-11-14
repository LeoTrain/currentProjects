namespace MenuFramework
{
    public class Window
    {
        private double _width;
        private double _height;
        public double Width
        {
            get { return _width; }
            private set
            {
                if (value < 0) throw new ArgumentException("Width must be more than 0.");
                if (value > Console.WindowWidth) throw new ArgumentException($"Width must be less than WindowWidth ({Console.WindowWidth}).");
                _width = value;
            }
        }
        public double Height
        {
            get { return _height; }
            private set
            {
                if (value < 0) throw new ArgumentException("Height must be more than 0.");
                if (value > Console.WindowHeight) throw new ArgumentException($"Height must be less than WindowHeight ({Console.WindowHeight}).");
                _height = value;
            }
        }

        public Window()
        {
           Width = Console.WindowWidth;
           Height = Console.WindowHeight;
        }

        public Window(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                DrawBorders();

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true).Key;
                    if (key == ConsoleKey.Q) break;
                }

                System.Threading.Thread.Sleep(100);
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
