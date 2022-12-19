namespace SingletonPattern
{
    public class PrintService
    {
        public Logger logger { get; private set; }

        public PrintService(Logger logger)
        {
            this.logger = logger;
        }

        public void Print(string content, int copies)
        {
            for (int i = 1; i < copies+1; i++)
            {
                logger.LogInformation($"Print {i} copy of {content}");
            }
        }
    }
}
