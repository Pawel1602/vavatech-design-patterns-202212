using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BridgePattern.UnitTests
{
    [TestClass]
    public class BluetoothRemoteControlSamsungLedTVTests
    {
        [TestMethod]
        public void SwitchOn_ShouldOnTrue()
        {
            // Arrange
            BluetoothRemoteControlSamsungLedTV ledTV = new BluetoothRemoteControlSamsungLedTV();

            // Act
            ledTV.SwitchOn();

            //
            Assert.IsTrue(ledTV.On);
        }

        [TestMethod]
        public void SwitchOn_ShouldOnFalse()
        {
            // Arrange
            BluetoothRemoteControlSamsungLedTV ledTV = new BluetoothRemoteControlSamsungLedTV();

            // Act
            ledTV.SwitchOff();

            //
            Assert.IsFalse(ledTV.On);
        }

        [TestMethod]
        public void SetChannel_ShouldSetCurrentChannel()
        {
            // Arrange
            BluetoothRemoteControlSamsungLedTV ledTV = new BluetoothRemoteControlSamsungLedTV();

            // Act
            ledTV.SetChannel(10);

            //
            Assert.AreEqual(10, ledTV.CurrentChannel);
        }
    }
}
