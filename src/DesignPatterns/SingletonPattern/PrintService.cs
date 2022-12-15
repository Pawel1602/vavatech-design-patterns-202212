namespace SingletonPattern
{
    public class PrintService
    {
        public Logger logger { get; set; }

        public PrintService()
        {
            logger = new Logger();
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
