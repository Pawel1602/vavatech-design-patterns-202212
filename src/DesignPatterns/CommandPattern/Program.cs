using System;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Command Pattern!");

            Message message = new Message("555000123", "555888000", "Hello World!");

            if (message.CanPrint())
            {
                message.Print();
            }

            if (message.CanSend())
            {
                message.Send();
            }    
        }
    }

}
