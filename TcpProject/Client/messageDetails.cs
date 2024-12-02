
namespace Client
{
    public class MessageDetails
    {
        public DateTime SentTime { get; private set; }
        public string Message { get; private set; }

        public MessageDetails(string message)
        {
            SentTime = DateTime.Now;
            Message = message;
        }

        public override string ToString() => $"{SentTime}-{Message}";
    }
}
