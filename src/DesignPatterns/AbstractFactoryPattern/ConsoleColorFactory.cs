using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    internal class ConsoleColorFactory
    {
        public static ConsoleColor Create(decimal amount)
        {
            if (amount == 0)
                return ConsoleColor.Green;
            else
                if (amount >= 200)
                return ConsoleColor.Red;
            else
                return ConsoleColor.White;
        }
    }
}
