using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class InfraredRemoteControlSamsungLedTV
    {
        public bool On { get; private set; }
        public byte CurrentChannel { get; private set; }

        public void SwitchOn()
        {
            Console.WriteLine($"Switch On by IR");
            On = true;
            Console.WriteLine("Samsung: Switch On");
        }
        public void SwitchOff()
        {
            Console.WriteLine($"Switch Off by IR");
            On = false;
            Console.WriteLine("Samsung: Switch Off");
        }
        public void SetChannel(byte number)
        {
            Console.WriteLine($"Set Channel by IR");
            CurrentChannel = number;
            Console.WriteLine($"Samsung: Setting channel #{number}");
        }
    }

    public class BluetoothRemoteControlSamsungLedTV
    {
        public bool On { get; private set; }
        public byte CurrentChannel { get; private set; }

        public void SwitchOn()
        {
            Console.WriteLine($"Switch On by BT");
            On = true;
            Console.WriteLine("Samsung: Switch On");
        }
        public void SwitchOff()
        {
            Console.WriteLine($"Switch Off by BT");
            On = false;
            Console.WriteLine("Samsung: Switch Off");
        }
        public void SetChannel(byte number)
        {
            Console.WriteLine($"Set Channel by BT");
            CurrentChannel = number;
            Console.WriteLine($"Samsung: Setting channel #{number}");
        }
    }

    public class InfraredRemoteControlSonyLedTV
    {
        public bool IsSwitchOn { get; private set; }
        public byte SelectedChannel { get; private set; }

        public void SwitchOn()
        {
            Console.WriteLine($"Switch On by IR");
            IsSwitchOn = true; 
            Console.WriteLine("Sony: Switch On");
            
        }
        public void SwitchOff()
        {
            Console.WriteLine($"Switch Off by IR");
            IsSwitchOn = false;
            Console.WriteLine("Sony: Switch Off");            
        }
        public void SetChannel(byte number)
        {
            Console.WriteLine($"Set Channel by IR");
            SelectedChannel = number;
            Console.WriteLine($"Sony: Setting channel #{number}");
        }
    }

    public class BluetoothRemoteControlSonyLedTV
    {
        public bool IsSwitchOn { get; private set; }
        public byte SelectedChannel { get; private set; }

        public void SwitchOn()
        {
            Console.WriteLine($"Switch On by BT");
            IsSwitchOn = true;
            Console.WriteLine("Sony: Switch On");
        }
        public void SwitchOff()
        {
            Console.WriteLine($"Switch Off by BT");
            IsSwitchOn = false;
            Console.WriteLine("Sony: Switch Off");
        }
        public void SetChannel(byte number)
        {
            Console.WriteLine($"Set Channel by BT");
            SelectedChannel = number;
            Console.WriteLine($"Sony: Setting channel #{number}");
        }
    }
}
