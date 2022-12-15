using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BridgePattern.UnitTests
{
    [TestClass]
    public class BluetoothRemoteControlSonyLedTVTests
    {
        [TestMethod]
        public void SwitchOn_ShouldOnTrue()
        {
            // Arrange
            BluetoothRemoteControlSonyLedTV ledTV = new BluetoothRemoteControlSonyLedTV();

            // Act
            ledTV.SwitchOn();

            //
            Assert.IsTrue(ledTV.IsSwitchOn);
        }

        [TestMethod]
        public void SwitchOn_ShouldOnFalse()
        {
            // Arrange
            BluetoothRemoteControlSonyLedTV ledTV = new BluetoothRemoteControlSonyLedTV();

            // Act
            ledTV.SwitchOff();

            //
            Assert.IsFalse(ledTV.IsSwitchOn);
        }

        [TestMethod]
        public void SetChannel_ShouldSetCurrentChannel()
        {
            // Arrange
            BluetoothRemoteControlSonyLedTV ledTV = new BluetoothRemoteControlSonyLedTV();

            // Act
            ledTV.SetChannel(10);

            //
            Assert.AreEqual(10, ledTV.SelectedChannel);
        }
    }
}
