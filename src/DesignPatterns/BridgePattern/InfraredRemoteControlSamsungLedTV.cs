using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    // Abstract Implementor
    public interface ILEDTV
    {
        bool On { get; set; }
        byte CurrentChannel { get; set; }

        void SwitchOn();
        void SwitchOff();

        void SetChannel(byte number);
    }

    // Abstract
    public abstract class RemoteControl
    {
        // Implementor
        protected ILEDTV ledTV;

        protected RemoteControl(ILEDTV ledTV)
        {
            this.ledTV = ledTV;
        }

        public abstract void SwitchOn();    
        public abstract void SwitchOff();
        public abstract void SetChannel(byte number);
    }

    public abstract class Power
    {
        protected ILEDTV ledTV;

        protected Power(ILEDTV ledTV)
        {
            this.ledTV = ledTV;
        }

        public abstract void SwitchOn();
        public abstract void SwitchOff();
    }

   
    public class BluetoothRemoteControl : RemoteControl
    {
        public BluetoothRemoteControl(ILEDTV ledTV) : base(ledTV)
        {
        }

        public override void SetChannel(byte number)
        {
            Console.WriteLine($"Set Channel by BT");
            ledTV.SetChannel(number);
        }

        public override void SwitchOff()
        {
            Console.WriteLine($"Switch Off by BT");
            ledTV.SwitchOff();
        }

        public override void SwitchOn()
        {
            Console.WriteLine($"Switch On by BT");
            ledTV.SwitchOn();
        }
    }
    public class InfraredRemoteControl : RemoteControl
    {
        public InfraredRemoteControl(ILEDTV ledTV) : base(ledTV)
        {
        }

        public override void SetChannel(byte number)
        {
            Console.WriteLine($"Set Channel by IR");
            ledTV.SetChannel(number);
        }

        public override void SwitchOff()
        {
            Console.WriteLine($"Switch Off by IR");
            ledTV.SwitchOff();
        }

        public override void SwitchOn()
        {
            Console.WriteLine($"Switch On by IR");
            ledTV.SwitchOn();
        }
    }

    public class SamsungLedTV : ILEDTV
    {
        public bool On { get; set; }
        public byte CurrentChannel { get; set; }

        public void SetChannel(byte number)
        {
            CurrentChannel = number;
            Console.WriteLine($"Samsung: Setting channel #{number}");
        }

        public void SwitchOff()
        {
            On = false;
            Console.WriteLine("Samsung: Switch Off");
        }

        public void SwitchOn()
        {            
            On = true;
            Console.WriteLine("Samsung: Switch On");
        }
    }
    public class SonyLedTV : ILEDTV
    {
        public bool On { get; set; }
        public byte CurrentChannel { get; set; }

        public void SetChannel(byte number)
        {
            CurrentChannel = number;
            Console.WriteLine($"Sony: Setting channel #{number}");
        }

        public void SwitchOff()
        {
            On = false;
            Console.WriteLine("Sony: Switch Off");
        }

        public void SwitchOn()
        {
            On = true;
            Console.WriteLine("Sony: Switch On");
        }
    }



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
