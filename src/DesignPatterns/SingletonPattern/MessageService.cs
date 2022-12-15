namespace SingletonPattern
{
    public class MessageService
    {
        public Logger logger;

        public MessageService()
        {
            logger = new Logger();
        }

        public void Send(string message)
        {
            logger.LogInformation($"Send {message}");
        }
    }
}
