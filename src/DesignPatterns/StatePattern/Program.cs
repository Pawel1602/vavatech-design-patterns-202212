using StateMachinePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace StatePattern
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            StateMachineTest();

            // StateTest();
        }

        private static void StateMachineTest()
        {
            var serviceCollection = new ServiceCollection()
                    .AddMediatR(Assembly.GetExecutingAssembly())
                    .BuildServiceProvider();

            var mediator = serviceCollection.GetRequiredService<IMediator>();

            while (true)
            {
                var order = new StateMachinePattern.OrderProxy(mediator);

                Console.WriteLine(order.Graph);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(order);
                Console.ResetColor();

                Console.WriteLine(order.Status);

                order.IsPaid = true;

                while (!(order.Status == OrderStatus.Cancelled || order.Status == OrderStatus.Completed))
                {
                    if (order.CanConfirm)
                        Console.Write("Confirm (Enter) ");

                    if (order.CanCancel)
                        Console.Write("(C)ancel ");

                    var key = Console.ReadKey().Key;

                    Console.WriteLine();

                    if (key == ConsoleKey.Enter)
                        order.Confirm();

                    if (key == ConsoleKey.C)
                        order.Cancel();

                    Console.WriteLine(order.Status);

                }

                Console.Clear();

            }
        }

        private static void StateTest()
        {
            while (true)
            {
                var order = new OrderProxy();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(order);
                Console.ResetColor();

                order.State.Dump();

                order.IsPaid = true;

                while (!(order.State is Cancelled || order.State is Completed))
                {
                    if (order.CanConfirm)
                        Console.Write("Confirm (Enter) ");

                    if (order.CanCancel)
                        Console.Write("(C)ancel ");

                    var key = Console.ReadKey().Key;

                    Console.WriteLine();

                    if (key == ConsoleKey.Enter)
                        order.Confirm();

                    if (key == ConsoleKey.C)
                        order.Cancel();

                    order.State.Dump();

                }

                Console.Clear();

            }
        }
    }
}
