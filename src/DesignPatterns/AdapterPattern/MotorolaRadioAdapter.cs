namespace AdapterPattern
{
    // Concrete adapter
    // Wariant obiektowy
    // Klasa adaptera implementuje interfejs, który zawiera w sobie klasę adaptowaną (Adaptee)
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
