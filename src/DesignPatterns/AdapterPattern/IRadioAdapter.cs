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

    // Concrete adapter
    class HyteraRadioAdapter : IRadioAdapter
    {
        // Adaptee
        private readonly HyteraRadio radio;

        public HyteraRadioAdapter()
        {
            radio = new HyteraRadio();
        }

        public void Send(string message, byte channel)
        {
            radio.Init();
            radio.SendMessage(channel, message);
            radio.Release();
        }
    }

    class MotoraRadioAdapter2 : MotorolaRadio, IRadioAdapter
    {
        private readonly string pincode;

        public MotoraRadioAdapter2(string pincode)
        {
            this.pincode = pincode;
        }

        public void Send(string message, byte channel)
        {
            base.PowerOn(pincode);
            base.SelectChannel(channel);
            base.Send(message);
            base.PowerOff();
        }
    }

    // Concrete adapter
    class MotorolaRadioAdapter : IRadioAdapter
    {
        // Adaptee
        private readonly MotorolaRadio radio;

        private readonly string pincode;

        public MotorolaRadioAdapter(string pincode)
        {
            radio = new MotorolaRadio();
            this.pincode = pincode;
        }

        public void Send(string message, byte channel)
        {
            radio.PowerOn(pincode);
            radio.SelectChannel(channel);
            radio.Send(message);
            radio.PowerOff();
        }
    }
}
