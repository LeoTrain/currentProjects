using Terminal.Gui;
using System.Text;
using System.Net.Sockets;

namespace Client
{
    public class ChatWindow : Window
    {
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
        private const string ServerAddress = "192.168.1.108";

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
                        string currentMessages = _messageDisplay.Text.ToString() ?? "";
                        _messageDisplay.Text = currentMessages + $"{DateTime.Now:HH:mm}: {message}\n";
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
