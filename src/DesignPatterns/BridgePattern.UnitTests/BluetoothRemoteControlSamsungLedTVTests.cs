using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BridgePattern.UnitTests
{


    [TestClass]
    public class BluetoothRemoteControlSamsungLedTVTests
    {
        private ILEDTV ledTV;
        private RemoteControl control;

        [TestInitialize]
        public void Init()
        {
            // Arrange
           this.ledTV = new SamsungLedTV();
           this.control = new BluetoothRemoteControl(ledTV);
        }

        [TestMethod]
        public void SwitchOn_ShouldOnTrue()
        {
            // Act
            ledTV.SwitchOn();

            // Assert
            Assert.IsTrue(ledTV.On);
        }

        [TestMethod]
        public void SwitchOn_ShouldOnFalse()
        {
            // Act
            ledTV.SwitchOff();

            // Assert
            Assert.IsFalse(ledTV.On);
        }

        [TestMethod]
        public void SetChannel_ShouldSetCurrentChannel()
        {
            // Act
            ledTV.SetChannel(10);

            //
            Assert.AreEqual(10, ledTV.CurrentChannel);
        }
    }
}
