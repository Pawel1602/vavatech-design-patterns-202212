using System;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace CommandPattern
{
    public interface ICommand
    {
        void Execute();
        bool CanExecute();
    }

    public class PrintCommand : ICommand
    {
        private readonly Message message;
        public int Copies { get; set; }
        public int SheetsQuantity { get; set; }

        public PrintCommand(Message message, int copies, int sheetsQuantity)
        {
            this.message = message;
            Copies = copies;
            SheetsQuantity = sheetsQuantity;
        }

        public void Execute()
        {
            for (int i = 0; i < Copies; i++)
            {
                Console.WriteLine($"Print message from <{message.From}> to <{message.To}> {message.Content}");
            }
        }
        public bool CanExecute()
        {
            return !string.IsNullOrEmpty(message.Content) && Copies <= SheetsQuantity;
        }
    }

    public class SendCommand : ICommand
    {
        private readonly Message message;

        public SendCommand(Message message)
        {
            this.message = message;
        }

        public void Execute()
        {
            Console.WriteLine($"Send message from <{message.From}> to <{message.To}> {message.Content}");
        }
        public bool CanExecute()
        {
            return !(string.IsNullOrEmpty(message.From) || string.IsNullOrEmpty(message.To) || string.IsNullOrEmpty(message.Content));
        }
    }

    public class Message
    {
        public Message(string from, string to, string content)
        {
            From = from;
            To = to;
            Content = content;
        }

        public string From { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
        public int SheetsQuantity { get; set; }
    }

}
