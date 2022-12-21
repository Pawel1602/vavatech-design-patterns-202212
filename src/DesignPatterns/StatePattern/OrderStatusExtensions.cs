using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    internal static class OrderStatusExtensions
    {
        public static void Dump(this OrderStatus status)
        {
            Console.ForegroundColor = Create(status);
            Console.WriteLine(status);
            Console.ResetColor();
        }

        // Metoda wytwórcza (fabrykująca)
        private static ConsoleColor Create(OrderStatus orderStatus) => orderStatus switch
        {
            OrderStatus.Pending => ConsoleColor.DarkYellow,
            OrderStatus.Sent => ConsoleColor.Green,
            OrderStatus.Delivered => ConsoleColor.Blue,
            OrderStatus.Completed => ConsoleColor.Black,
            OrderStatus.Cancelled => ConsoleColor.DarkGray,
            _ => Console.ForegroundColor,
        };
    }
}
