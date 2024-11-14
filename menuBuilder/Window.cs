namespace MenuBuilder
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
                _width = value;
            }
        }
        public double Height
        {
            get { return _height; }
            private set
            {
                if (value < 0) throw new ArgumentException("Height must be more than 0.");
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
            DrawBorders();
        }

        protected void DrawBorders()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < _width; i++)
                Console.Write("=");
            for (int i = 1; i < _height - 2; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("||");
                Console.SetCursorPosition((int)_width, i);
                Console.Write("||");
            }
            Console.SetCursorPosition(0, (int)_height);
            for (int i = 0; i < _width; i++)
                Console.Write("=");
        }
    }
}
