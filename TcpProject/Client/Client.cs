using System.Text;
using System.Net.Sockets;

namespace Client
{
    class Clients
    {
        private const int Port = 6000;
        private const string ServerAddress = "192.168.1.11";

        private bool _isRunning;
        private readonly List<User> _connectedUsers = new();
        private readonly List<string> _currentChat = new();
        private User _thisUser;

        public Clients()
        {
            _thisUser = new User("EmptyName", new TcpClient());
        }

        public async Task StartAsync()
        {
            try
            {
                string username = GetUsernameFromInput();
                if (string.IsNullOrEmpty(username)) return;

                _thisUser = new User(username, new TcpClient()) { Color = RandomColor() };
                _connectedUsers.Add(_thisUser);

                await ConnectToServer();
                await SendUsernameToServer();

                await Task.WhenAll(ListenForMessages(), HandleInput());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Disconnect();
            }
        }

        private string GetUsernameFromInput()
        {
            Console.Write("Enter your username: ");
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        private async Task ConnectToServer()
        {
            _isRunning = true;
            await _thisUser.Client.ConnectAsync(ServerAddress, Port);
            Console.WriteLine($"Connected to server {ServerAddress}:{Port}");
        }

        private async Task SendUsernameToServer()
        {
            byte[] data = Encoding.UTF8.GetBytes(_thisUser.Name);
            await _thisUser.Client.GetStream().WriteAsync(data, 0, data.Length);
        }

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
            Console.ResetColor();
        }

        private async Task HandleInput()
        {
            while (_isRunning)
            {
                Display();

                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                var message = new MessageDetails(input);
                _thisUser.NewMessage(message);

                _currentChat.Add(FormatMessage(_thisUser, message));
                await SendMessageToServer(input);
            }
        }

        private async Task SendMessageToServer(string message)
        {
            string formattedMessage = $"MESSAGE:{_thisUser.Name}:{message}";
            byte[] data = Encoding.UTF8.GetBytes(formattedMessage);
            await _thisUser.Client.GetStream().WriteAsync(data, 0, data.Length);
        }

        private async Task ListenForMessages()
        {
            byte[] buffer = new byte[1024];
            NetworkStream stream = _thisUser.Client.GetStream();

            while (_isRunning)
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead <= 0) continue;

                ProcessReceivedMessage(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                Display();
            }
        }

        private void ProcessReceivedMessage(string receivedContent)
        {
            string? username = null;
            string message = string.Empty;

            if (receivedContent.StartsWith("CONNECTION:"))
            {
                username = receivedContent[11..];
                message = $"{username} has connected to the room.";
            }
            else if (receivedContent.StartsWith("MESSAGE:"))
            {
                var parts = receivedContent[8..].Split(':', 2);
                if (parts.Length == 2)
                {
                    username = parts[0];
                    message = parts[1];
                }
            }
            else if (receivedContent.StartsWith("DISCONNECT:"))
            {
                username = receivedContent[11..];
                message = $"{username} has disconnected from the room.";
            }

            if (!string.IsNullOrEmpty(username))
            {
                AddUserIfNotExists(username);
                _currentChat.Add(FormatMessage(_connectedUsers.First(u => u.Name == username), new MessageDetails(message)));
            }
        }

        private void AddUserIfNotExists(string username)
        {
            if (_connectedUsers.Any(u => u.Name == username)) return;

            var newUser = new User(username, new TcpClient()) { Color = RandomColor() };
            _connectedUsers.Add(newUser);
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

        private static ConsoleColor RandomColor()
        {
            return (ConsoleColor)new Random().Next((int)ConsoleColor.Black, (int)ConsoleColor.White);
        }

        private void Disconnect()
        {
            _isRunning = false;
            _thisUser.Client.Close();
            Console.WriteLine("Disconnected from server.");
        }
    }
}
