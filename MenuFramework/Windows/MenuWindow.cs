using Figgle;

namespace MenuFramework
{
   public class MenuWindow : Window
   {
        private string _title = "Menu";
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
        public MenuWindow() : base() {}
        public MenuWindow(double width, double height) {}
        public MenuWindow(double width, double height, string title) : base(width, height)
        {
            Title = title;
        }

        protected override void Display()
        {
            base.Display();
            DisplayTitle();
        }

        private void DisplayTitle()
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

   }
}
