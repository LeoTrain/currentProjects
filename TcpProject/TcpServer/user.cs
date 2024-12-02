using System.Net.Sockets;

namespace TcpServer
{
    public class User
    {
        public List<MessageDetails> Messages;
        public string Name { get; private set; }
        public TcpClient Client { get; private set; }

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
    }
}
