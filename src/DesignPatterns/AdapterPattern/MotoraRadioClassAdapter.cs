namespace AdapterPattern
{
    // Wariant klasowy
    // Wykorzystywane jest dziedziczenie.
    class MotoraRadioClassAdapter : MotorolaRadio, IRadioAdapter
    {
        private readonly string pincode;

        public MotoraRadioClassAdapter(string pincode)
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
}
