namespace AdapterPattern
{
    // Wariant klasowy
    // Wykorzystywane jest dziedziczenie.
    class HyteraRadioClassAdapter : HyteraRadio, IRadioAdapter
    {
        public void Send(string message, byte channel)
        {
            base.Init();
            base.SendMessage(channel, message);
            base.Release();
        }
    }
}
