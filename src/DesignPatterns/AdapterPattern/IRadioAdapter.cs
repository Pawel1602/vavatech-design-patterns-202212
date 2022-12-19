using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    // Abstract adapter
    internal interface IRadioAdapter
    {
        void Send(string message, byte channel);
    }
}
