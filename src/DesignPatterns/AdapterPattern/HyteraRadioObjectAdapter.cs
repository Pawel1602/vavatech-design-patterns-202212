namespace AdapterPattern
{
    // Concrete adapter
    // Wariant obiektowy
    // Klasa adaptera implementuje interfejs, który zawiera w sobie klasę adaptowaną (Adaptee)
    class HyteraRadioObjectAdapter : IRadioAdapter
    {
        // Adaptee
        private readonly HyteraRadio radio;

        public HyteraRadioObjectAdapter()
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
}
