using System;

namespace CommandPattern
{
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

     
        public void Send()
        {
            Console.WriteLine($"Send message from <{From}> to <{To}> {Content}");
        }

        public bool CanSend()
        {
            return !(string.IsNullOrEmpty(From) || string.IsNullOrEmpty(To) || string.IsNullOrEmpty(Content));
        }

        public void Print(byte copies = 1)
        {
            for (int i = 0; i < copies; i++)
            {
                Console.WriteLine($"Print message from <{From}> to <{To}> {Content}");
            }
        }

        public bool CanPrint()
        {
            return string.IsNullOrEmpty(Content);
        }



    }

}
