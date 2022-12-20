using System;
using System.Collections.Generic;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Command Pattern!");

            Message message = new Message("555000123", "555888000", "Hello World!");

            Queue<ICommand> commands = new Queue<ICommand>();
            commands.Enqueue(new PrintCommand(message, 3, 10));
            commands.Enqueue(new SendCommand(message));
            commands.Enqueue(new SendCommand(message));
            commands.Enqueue(new SendCommand(message));
            
            while (commands.Count > 0)
            {
                ICommand command = commands.Dequeue();

                if (command.CanExecute())
                {
                    command.Execute();
                }
            }

            


        }
    }

}
