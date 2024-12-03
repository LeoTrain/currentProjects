using System.Net.Sockets;

namespace Client
{
    public class User
    {
        public List<MessageDetails> Messages { get; private set; }
        public string Name { get; private set; }
        public TcpClient Client { get; private set; }
        public ConsoleColor Color { get; set; }

        public User(string name, TcpClient client)
        {
            Name = name;
            Client = client;
            Messages = new List<MessageDetails>();
        }

        public void NewMessage(MessageDetails message)
        {
            Messages.Add(message);
        }

        public MessageDetails LastMessage
        {
            get { return Messages.LastOrDefault(); }
            private set { Messages.Add(value); }
        }

        public void ChangeName(string newName)
        {
            if (!string.IsNullOrEmpty(newName))
            {
                Name = newName;
            }
        }
    }
}
