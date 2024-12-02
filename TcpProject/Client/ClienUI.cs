using Terminal.Gui;
using System.Threading;

namespace Client
{
    partial class Clients
    {
        private const ConsoleColor _backgroundColor = ConsoleColor.White;
        private const ConsoleColor _foregroundColor = ConsoleColor.Black;

        public void Start()
        {
            Terminal.Gui.Toplevel top = Application.Top;

            Window window = new Window("Chit Chat")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
            };

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
                

            /*Label label = new Label("Hello ...")*/
            /*{*/
            /*    X = Pos.Center(),*/
            /*    Y = Pos.Center() - 5,*/
            /*};*/
            /**/
            /*Button button = new Button("Click me")*/
            /*{*/
            /*    X = Pos.Center(),*/
            /*    Y = Pos.Center() - 1,*/
            /*};*/
            /**/
            /*Button button2 = new Button("Quit")*/
            /*{*/
            /*    X = Pos.Center() - 20,*/
            /*    Y = Pos.Center() - 1,*/
            /*};*/
            /*button.Clicked += () => MessageBox.Query("Button clicked", "This is the message that you clicked", "Ok");*/
            /*button2.Clicked += () => Application.RequestStop();*/
            /*window.Add(label, button, button2);*/

            top.Add(menu, window);
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
