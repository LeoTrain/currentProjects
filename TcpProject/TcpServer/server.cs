using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpServer
{
    class Server
    {
        private TcpListener _server;
        private bool _isRunning;
        private List<TcpClient> _clients = new List<TcpClient>();
        private Dictionary<TcpClient, string> _clientUsernames;

        public Server(string ip, int port)
        {
            _server = new TcpListener(IPAddress.Parse(ip), port); 
            _clientUsernames = new Dictionary<TcpClient, string>();
        }

        public async Task StartAsync()
        {
            _isRunning = true;
            _server.Start();
            Console.WriteLine("Server started. Waiting for connections...");

            while (_isRunning)
            {
                TcpClient client = await _server.AcceptTcpClientAsync();
                _clients.Add(client);
                Console.WriteLine("Client connected.");

                _ = HandleClientAsync(client);
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];

            try
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string username = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                if (string.IsNullOrEmpty(username))
                {
                    Console.WriteLine("Client tried to connect without a username. Disconnecting...");
                    client.Close();
                    return;
                }
                _clientUsernames[client] = username;
                Console.WriteLine($"{username} has joined the chat.");
                await BroadcastMessage($"{username} has joined the chat.", client);

                while (_isRunning && client.Connected)
                {
                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"{message}");
                    await BroadcastMessage($"{message}", client);

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error handling client: {exception}");
            }
            finally
            {
                if (_clientUsernames.ContainsKey(client))
                {
                    string username = _clientUsernames[client];
                    Console.WriteLine($"{username} has left the chat.");
                    await BroadcastMessage($"{username} has left the chat", client);
                    _clientUsernames.Remove(client);
                }
                client.Close();
                _clients.Remove(client);
            }
        }

        private async Task BroadcastMessage(string message, TcpClient sender)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            foreach (TcpClient client in _clients)
            {
                if (client == sender)
                    continue;
                try
                {
                    await client.GetStream().WriteAsync(data, 0, data.Length);
                }
                catch (Exception)
                {
                    _clients.Remove(client);
                }
            }
        }
    }
}
