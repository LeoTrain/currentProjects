namespace MenuBuilder
{
    public static class MessageBox
    {
        public static void Display(string title, string[] message, MessageBoxType type)
        {
            var screenCenter = (Console.WindowWidth, Console.WindowHeight);
            int longestMessageLength = message.Max(line => line.Length);
            int boxHeight = message.Length + 5;
            int boxWidth = longestMessageLength + 6;
            int xStart = (screenCenter.Item1 - boxWidth) / 2;
            int yStart = (screenCenter.Item2 - boxHeight) / 2;

            DrawBorder(boxWidth, boxHeight, xStart, yStart);
            ClearContent(boxWidth, boxHeight, xStart, yStart);
            DrawTitle(title, boxWidth, xStart, yStart);
            DrawContent(message, xStart, yStart);

            Console.ReadLine();
        }

        private static void DrawBorder(int boxWidth, int boxHeight, int xStart, int yStart)
        {
            Console.SetCursorPosition(0, 0);
            Menu.DrawBox(boxWidth, boxHeight, xStart, yStart);
        }

        private static void ClearContent(int boxWidth, int boxHeight, int xStart, int yStart)
        {
            for (int i = 1; i < boxWidth; i++)
            {
                for (int j = 1; j < boxHeight - 1; j++)
                {
                    Console.SetCursorPosition(xStart + i, yStart + j);
                    Console.Write(" ");
                }
            }
        }

        private static void DrawContent(string[] message, int xStart, int yStart)
        {
            for (int i = 0; i < message.Length; i++)
            {
                int centeredX = xStart + (message[i].Length - message[i].Length) / 2 + 2;
                Console.SetCursorPosition(centeredX, yStart + 2 + i);
                Console.WriteLine(message[i]);
            }
        }

        private static void DrawTitle(string title, int boxWidth, int xStart, int yStart)
        {
            int centeredX = xStart + (boxWidth - title.Length) / 2;
            Console.SetCursorPosition(centeredX, yStart + 1);
            Console.WriteLine(title);
        }
    }
}

