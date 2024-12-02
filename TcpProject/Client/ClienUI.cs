namespace Client
{
    partial class Clients
    {
        private const ConsoleColor _backgroundColor = ConsoleColor.White;
        private const ConsoleColor _foregroundColor = ConsoleColor.Black;
        private void Display()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            foreach (string message in _currentChat)
            {
                DisplayMessage(message);
            }

            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.Write("Enter your message: ");
        }

        private void DisplayMessage(string message)
        {
            string username = GetUsernameFromMessage(message);
            User user = _connectedUsers.FirstOrDefault(u => u.Name == username) ?? new User("Unknown", null) { Color = ConsoleColor.Gray };

            Console.ForegroundColor = user.Color;
            Console.WriteLine(message);
            Console.ForegroundColor = _foregroundColor;
            Console.ResetColor();
        }

        private string GetUsernameFromInput()
        {
            Console.BackgroundColor = _backgroundColor;
            Console.ForegroundColor = _foregroundColor;
            Console.Clear();
            string usernameInput = "Enter your username: ";
            Console.SetCursorPosition((Console.WindowWidth - usernameInput.Length) / 2, Console.WindowHeight / 2 );
            Console.Write(usernameInput);
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        private static string FormatMessage(User user, MessageDetails message)
        {
            return $"{message.SentTime:HH:mm} - {user.Name}: {message.Message}";
        }

        private static string GetUsernameFromMessage(string message)
        {
            string[] parts = message.Split(" - ");
            return parts.Length > 1 ? parts[1].Split(':')[0] : "Unknown";
        }


    }
}
