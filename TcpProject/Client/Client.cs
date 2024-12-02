using System.Text;
using System.Net.Sockets;

namespace Client
{
    class Clients
    {
        private int _windowWidth;
        private int _windowHeight;
        private List<string> _messages;
        private string _serverAddress;
        private int _port;
        private bool _isRunning;
        private TcpClient _client;
        private string _username;
        private Dictionary<string, ConsoleColor> _connectedUsers;

        public Clients()
        {
            _windowWidth = Console.WindowWidth;
            _windowHeight = Console.WindowHeight - 2;
            _messages = new List<string>();
            _serverAddress = "192.168.1.11";
            _port = 6000;
            _client = new TcpClient();
            _username = "";
            _connectedUsers = new Dictionary<string, ConsoleColor>();
        }

        private void Display()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            foreach (string message in _messages)
            {
                string[] parts = message.Split(":", 2);
                if (parts.Length == 2 && _connectedUsers.ContainsKey(parts[0]))
                {
                    Console.ForegroundColor = _connectedUsers[parts[0]];
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.SetCursorPosition(0, _windowHeight);
            Console.Write("Enter your message: ");
        }

        private async Task HandleInput()
        {
            while (_isRunning)
            {
                Display();
                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    continue;

                byte[] data = Encoding.UTF8.GetBytes($"{_username}: {input}");
                await _client.GetStream().WriteAsync(data, 0, data.Length);
                _messages.Add($"Me: {input}");
            }
        }

        private async Task ListenForMessages()
        {
            byte[] buffer = new byte[1024];
            NetworkStream stream = _client.GetStream();

            while (_isRunning)
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    _messages.Add(message);

                    // Adding new users to _connectedUsers
                    string[] parts = message.Split(":");
                    string user = parts[0];
                    if (!_connectedUsers.ContainsKey(user))
                    {
                        _connectedUsers[user] = RandomColor();
                    }

                    Display();
                }
            }
        }

        public async Task StartAsync()
        {
            try
            {
                Console.Write("Enter your username: ");
                _username = Console.ReadLine() ?? "NoUsername";

                if (string.IsNullOrEmpty(_username))
                {
                    Console.WriteLine("Username cannot be empty.");
                    return ;
                }

                _isRunning = true;
                await _client.ConnectAsync(_serverAddress, _port);
                Console.WriteLine($"Connected to server {_serverAddress}:{_port}");

                byte[] data = Encoding.UTF8.GetBytes(_username);
                await _client.GetStream().WriteAsync(data, 0, _username.Length);

                Task listenTask = ListenForMessages();
                Task inputTask = HandleInput();

                await Task.WhenAll(listenTask, inputTask);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error starting async: {exception}");
            }
            finally
            {
                _client.Close();
                Console.WriteLine("Disconnected from server.");
            }
        }

        private ConsoleColor RandomColor()
        {
            Random random = new Random();
            ConsoleColor randomColor = (ConsoleColor) random.Next((int)ConsoleColor.Black, (int)ConsoleColor.Yellow);
            return randomColor;
        }
    }
}
