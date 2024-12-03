using Terminal.Gui;

namespace Client
{
    partial class Clients
    {
        private const ConsoleColor _backgroundColor = ConsoleColor.White;
        private const ConsoleColor _foregroundColor = ConsoleColor.Black;
        string currenttxt = "";
        private ColorScheme _mainColorScheme = new ColorScheme
        {
            Normal = Application.Driver.MakeAttribute(Color.White, Color.Blue),
            Focus = Application.Driver.MakeAttribute(Color.Black, Color.White),
            HotNormal = Application.Driver.MakeAttribute(Color.Cyan, Color.Blue),
            HotFocus = Application.Driver.MakeAttribute(Color.White, Color.Cyan)
        };
        private ColorScheme _drakulaColorScheme = new ColorScheme
        {
            Normal = Application.Driver.MakeAttribute(Color.BrightMagenta, Color.Black),
            Focus = Application.Driver.MakeAttribute(Color.White, Color.BrightMagenta),
            HotNormal = Application.Driver.MakeAttribute(Color.BrightCyan, Color.Black),
            HotFocus = Application.Driver.MakeAttribute(Color.BrightYellow, Color.BrightMagenta)
        };
        private ColorScheme _chatColorScheme = new ColorScheme
        {
            Normal = Application.Driver.MakeAttribute(Color.White, Color.Black),
            Focus = Application.Driver.MakeAttribute(Color.Black, Color.Gray)
        };
        private ColorScheme _gruvboxDarkColorScheme = new ColorScheme {
            Normal = Application.Driver.MakeAttribute(Color.BrightYellow, Color.Black),
            Focus = Application.Driver.MakeAttribute(Color.White, Color.DarkGray),
            HotNormal = Application.Driver.MakeAttribute(Color.BrightRed, Color.Black),
            HotFocus = Application.Driver.MakeAttribute(Color.BrightYellow, Color.DarkGray)
        };
        private ColorScheme _solarizedLightColorScheme = new ColorScheme {
            Normal = Application.Driver.MakeAttribute(Color.Black, Color.BrightYellow),
            Focus = Application.Driver.MakeAttribute(Color.Blue, Color.White),
            HotNormal = Application.Driver.MakeAttribute(Color.BrightGreen, Color.BrightYellow),
            HotFocus = Application.Driver.MakeAttribute(Color.Red, Color.White)
        };


        private Window InitChatWindow()
        {
            Window chatWindow = new Window("Chat")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
                ColorScheme = _gruvboxDarkColorScheme,
            };

            TextView messageDisplay = new TextView
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill() - 3,
                ReadOnly = true,
                Text = $"You joined the chat at {DateTime.Now:HH:mm}\n"
            };

            TextField inputField = new TextField("==> ")
            {
                X = 1,
                Y = Pos.Bottom(messageDisplay) + 1,
                Width = Dim.Fill() - 12
            };

            Button sendMessageButton = new Button("Send")
            {
                X = Pos.Right(inputField) + 1,
                Y = Pos.Bottom(messageDisplay) + 1
            };

            sendMessageButton.Clicked += () =>
            {
                string message = inputField.Text.ToString() ?? "ErrorSendMessageButton";;
                if (!string.IsNullOrWhiteSpace(message))
                {
                    Application.MainLoop.Invoke(() =>
                    {
                        string currentMessages = messageDisplay.Text.ToString() ?? "";
                        messageDisplay.Text = currentMessages + $"{DateTime.Now:HH:mm}: {message}\n";
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

            chatWindow.Add(inputField, messageDisplay, sendMessageButton);
            chatWindow.FocusFirst();

            return chatWindow;
        }

        private MenuBar InitMenuBar()
        {
            MenuBar menu = new MenuBar(new MenuBarItem[]
                    {
                        new MenuBarItem("_File", new MenuItem[]
                        {
                            new MenuItem("_Quit", "Quit the application", () => Application.RequestStop())
                        }),
                        new MenuBarItem("_Help", new MenuItem[]
                        {
                            new MenuItem("_About", "About this app", () => MessageBox.Query("About", "Blablablablabla", "ok"))
                        }),
                    });
            return menu;
        }

        public void Start()
        {
            Terminal.Gui.Toplevel top = Application.Top;
            Window chatWindow = InitChatWindow();
            MenuBar menuBar = InitMenuBar();

            top.Add(menuBar, chatWindow);
            Application.Run();
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
