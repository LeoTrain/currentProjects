using Terminal.Gui;
using System.Text;
using System.Net.Sockets;

namespace Client
{
    public class ChatWindow : Window
    {
        public List<string> ConnectedUsers = new();
        private ColorScheme _gruvboxDarkColorScheme = new ColorScheme
        {
            Normal = Application.Driver.MakeAttribute(Color.BrightYellow, Color.Black),
            Focus = Application.Driver.MakeAttribute(Color.White, Color.DarkGray),
            HotNormal = Application.Driver.MakeAttribute(Color.BrightRed, Color.Black),
            HotFocus = Application.Driver.MakeAttribute(Color.BrightYellow, Color.DarkGray)
        };
        private TextView _messageDisplay;
        private LoginWindow _loginWindow;

        private User _thisUser = new User("EmptyName", new TcpClient());
        private readonly List<string> _currentChat = new();
        private bool _isRunning = true;
        private const int Port = 6000;
        private const string ServerAddress = "192.168.31.116";

        public ChatWindow()
        {
            _messageDisplay = new TextView
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill() - 3,
                ReadOnly = true,
                ColorScheme = Colors.Base,
                Text = ""
            };
            _loginWindow = new LoginWindow(this);
            Title = "ChatWindow";
            Visible = false;

            X = 0;
            Y = 1;
            Width = Dim.Fill();
            Height = Dim.Fill();
            ColorScheme = _gruvboxDarkColorScheme;

            TextField inputField = new TextField("==> ")
            {
                X = 1,
                Y = Pos.Bottom(_messageDisplay) + 1,
                Width = Dim.Fill() - 12,
                ColorScheme = Colors.Menu
            };

            Button sendMessageButton = new Button("Send")
            {
                X = Pos.Right(inputField) + 1,
                Y = Pos.Bottom(_messageDisplay) + 1
            };

            sendMessageButton.Clicked += () =>
            {
                string message = inputField.Text.ToString()?[4..] ?? "ErrorSendMessageButton";;
                if (!string.IsNullOrWhiteSpace(message))
                {
                    Application.MainLoop.Invoke(() =>
                    {
                        AddMessageToDisplay(message);
                        SendMessageToServer(message);
                    });
                    inputField.Text = "==> ";
                }
            };

            inputField.KeyPress += (args) =>
            {
                if (args.KeyEvent.Key == Key.Enter)
                {
                    sendMessageButton.OnClicked();
                    args.Handled = true;
                }
            };

            Add(_messageDisplay, inputField, sendMessageButton);
        }

        public void AddUserName(string username)
        {
            _thisUser.ChangeName(username);
            _messageDisplay.Text = $"Hello {_thisUser.Name}, you joined the chat at {DateTime.Now:HH:mm}\n";
        }

        public async void Switch(string username)
        {
            this.Visible = true;
            AddUserName(username);
            await ConnectToServer();
            await SendUsernameToServer();
            await ListenForMessages();
        }

        private async Task ConnectToServer()
        {
            try
            {
                _isRunning = true;
                await _thisUser.Client.ConnectAsync(ServerAddress, Port);
                Application.MainLoop.Invoke(() =>
                {
                    MessageBox.Query("Connected", $"Connected to server {ServerAddress}:{Port}", "OK");
                });
            }
            catch (Exception)
            {
                Application.MainLoop.Invoke(() =>
                {
                    MessageBox.ErrorQuery("Error", $"Not able to connect", "OK");
                });
            }
        }

        private async Task SendUsernameToServer()
        {
            byte[] data = Encoding.UTF8.GetBytes(_thisUser.Name);
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
            }
        }

        private async void SendMessageToServer(string message)
        {
            string formattedMessage = $"MESSAGE:{_thisUser.Name}:{message}";
            byte[] data = Encoding.UTF8.GetBytes(formattedMessage);
            await _thisUser.Client.GetStream().WriteAsync(data, 0, data.Length);
        }

        private void ProcessReceivedMessage(string receivedContent)
        {
            string? username = null;
            string message = string.Empty;

            if (receivedContent.StartsWith("CONNECTION:"))
            {
                username = receivedContent[11..];
                message = $"{username} has connected to the room.";
                AddMessageToDisplay(message);
            }
            else if (receivedContent.StartsWith("MESSAGE:"))
            {
                var parts = receivedContent[8..].Split(':', 2);
                if (parts.Length == 2)
                {
                    username = parts[0];
                    message = parts[1];
                    string completeMessage = $"{username}: {message}";
                    AddMessageToDisplay(completeMessage);
                }
            }
            else if (receivedContent.StartsWith("DISCONNECT:"))
            {
                username = receivedContent[11..];
                message = $"{username} has disconnected from the room.";
            }
            else
            {
                Application.MainLoop.Invoke(
                        () => MessageBox.Query("Hello", receivedContent, "OK"));
                foreach (string userName in receivedContent.Split(":"))
                {
                    _currentChat.Add(userName);
                }
            }
        }

        private void AddMessageToDisplay(string newMessage)
        {
            string currentMessages = _messageDisplay.Text.ToString() ?? "";
            _messageDisplay.Text = currentMessages + $"{DateTime.Now:HH:mm} - {newMessage}\n";
        }

        public override void OnVisibleChanged()
        {
            base.OnVisibleChanged();

            if (Visible)
            {
                MessageBox.Query("Chat entered", "You have entered the chat", "OK");
            }
        }
    }
}
