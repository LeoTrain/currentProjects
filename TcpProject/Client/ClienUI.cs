using Terminal.Gui;

namespace Client
{
    public partial class Clients
    {
        private List<string> _connectedUsers = new();
        private const ConsoleColor _backgroundColor = ConsoleColor.White;
        private const ConsoleColor _foregroundColor = ConsoleColor.Black;
        string currenttxt = "";
        string _currentUsername = "";
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
                    new MenuItem("_About", "About this app", () => MessageBox.Query("About", "Blablablablabla", "OK"))
                }),
                new MenuBarItem("_Users", new MenuItem[]
                {
                    new MenuItem("Users", "Show connected Users", () => ShowConnectedUsers())
                }),
            });
            return menu;
         }

        public void Start()
        {
            Terminal.Gui.Toplevel top = Application.Top;
            MenuBar menuBar = InitMenuBar();
            ChatWindow chatWindow = new ChatWindow();
            LoginWindow loginWindow = new LoginWindow(chatWindow); 
            top.Add(menuBar, loginWindow, chatWindow);
            _connectedUsers = chatWindow.ConnectedUsers;
            Application.Run();
        }

        public void ShowConnectedUsers()
        {
            Application.Top.MostFocused.Visible = false;
            Window connectedUsers = new Window("Connected Users")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill() ,
                Height = Dim.Fill(),
                Visible = true,
            };
            TextView userDisplay = new TextView()
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill() - 2,
                ReadOnly = true,
                Text = ""
            };
            foreach (string name in _connectedUsers)
            {
                userDisplay.Text += $"{name}\n";
            }
            connectedUsers.Add(userDisplay);
            Application.Top.Add(connectedUsers);
        }
    }
}
