using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpServer
{
    class Server
    {
        private readonly TcpListener _server;
        private readonly List<User> _users = new();
        private bool _isRunning;

        public Server(string ip, int port)
        {
            _server = new TcpListener(IPAddress.Parse(ip), port);
        }

        public async Task StartAsync()
        {
            _isRunning = true;
            _server.Start();
            Console.WriteLine("Server started. Waiting for connections...");

            while (_isRunning)
            {
                var client = await _server.AcceptTcpClientAsync();
                Console.WriteLine($"Client connected: {client.Client.RemoteEndPoint}");
                _ = HandleClientAsync(client);
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            var stream = client.GetStream();
            var buffer = new byte[1024];

            try
            {
                // Receive username
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string username = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                if (string.IsNullOrEmpty(username))
                {
                    Console.WriteLine("Client tried to connect without a username. Disconnecting...");
                    client.Close();
                    return;
                }

                // Add user and notify others
                var currentUser = new User(username, client);
                _users.Add(currentUser);
                await BroadcastMessageAsync($"CONNECTION:{currentUser.Name}", currentUser);
                Console.WriteLine($"{currentUser.Name} has joined the chat.");

                // Listen for messages
                while (_isRunning && client.Connected)
                {
                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string messageContent = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                    if (messageContent.StartsWith("MESSAGE:"))
                    {
                        currentUser.NewMessage(new MessageDetails(messageContent));
                        await BroadcastMessageAsync(messageContent, currentUser);
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling client: {ex.Message}");
            }
            finally
            {
                await RemoveUserAsync(client);
            }
        }

        private async Task RemoveUserAsync(TcpClient client)
        {
            var user = _users.FirstOrDefault(u => u.Client == client);
            if (user != null)
            {
                _users.Remove(user);
                await BroadcastMessageAsync($"DISCONNECT:{user.Name}", user);
                Console.WriteLine($"{user.Name} has left the chat.");
                user.Client.Close();
            }
        }

        private async Task BroadcastMessageAsync(string message, User sender)
        {
            Console.WriteLine($"Broadcasting message: {message}");
            var data = Encoding.UTF8.GetBytes(message);

            foreach (var user in _users)
            {
                if (user.Client == sender.Client) continue;

                try
                {
                    await user.Client.GetStream().WriteAsync(data, 0, data.Length);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Failed to send message to {user.Name}. Removing user.");
                    user.Client.Close();
                    _users.Remove(user);
                }
            }
        }

        private string GetConnectedUsers()
        {
            return System.Text.Json.JsonSerializer.Serialize(_users.Select(u => u.Name));
        }
    }
}
