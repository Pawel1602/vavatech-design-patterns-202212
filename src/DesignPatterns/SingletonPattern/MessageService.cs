namespace SingletonPattern
{
    public class MessageService
    {
        public Logger logger;

        public MessageService(Logger logger)
        {
            this.logger = logger;
        }

        public void Send(string message)
        {
            logger.LogInformation($"Send {message}");
        }
    }
}
