using Terminal.Gui;


namespace Client
{
    public class LoginWindow : Window
    {
        private ColorScheme _drakulaColorScheme = new ColorScheme
        {
            Normal = Application.Driver.MakeAttribute(Color.BrightMagenta, Color.Black),
            Focus = Application.Driver.MakeAttribute(Color.White, Color.BrightMagenta),
            HotNormal = Application.Driver.MakeAttribute(Color.BrightCyan, Color.Black),
            HotFocus = Application.Driver.MakeAttribute(Color.BrightYellow, Color.BrightMagenta)
        };
        public string UserName = "";
        private ChatWindow _chatWindow;
        private bool _isRunning;

        public LoginWindow(ChatWindow chatWindow)
        {
            _chatWindow = chatWindow;
            Title = $"Example App ({Application.QuitKey} to quit)";
            ColorScheme = _drakulaColorScheme;

            string usernameLabelText = "Username:";

            Label usernameLabel = new Label
            {
                Text = usernameLabelText,
                X = Pos.Center() - (usernameLabelText.Length * 2),
                Y = Pos.Center() - 1
            };

            var userNameText = new TextField
            {
                X = Pos.Right (usernameLabel) + 1,
                Y = Pos.Center() - 1,
                Width = Dim.Percent(20)
            };

            var passwordLabel = new Label
            {
                Text = "Password:",
                X = Pos.Left (usernameLabel),
                Y = Pos.Bottom (usernameLabel) + 1
            };

            var passwordText = new TextField
            {
                Secret = true,
                X = Pos.Left (userNameText),
                Y = Pos.Top (passwordLabel),
                Width = Dim.Percent(20)
            };

            var btnLogin = new Button
            {
                Text = "Login",
                Y = Pos.Bottom (passwordLabel) + 1,
                X = Pos.Center (),
                IsDefault = true
            };

            btnLogin.Clicked += () =>
            {

                if (CheckPassword(userNameText.Text.ToString() ?? "", passwordText.Text.ToString() ?? ""))
                {
                    MessageBox.Query ("Logging In", "Login Successful", "Ok");
                    UserName = userNameText.Text.ToString() ?? "";
                    this.Visible = false;
                    _chatWindow.Switch(UserName);
                }
                else
                {
                    MessageBox.ErrorQuery ("Logging In", "Incorrect username or password", "Ok");
                }
            };

            Add (usernameLabel, userNameText, passwordLabel, passwordText, btnLogin);
        }

        private bool CheckPassword(string username, string password)
        {
            if (username != string.Empty && password != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

