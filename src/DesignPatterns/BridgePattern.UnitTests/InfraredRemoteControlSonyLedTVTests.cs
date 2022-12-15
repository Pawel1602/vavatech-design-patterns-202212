using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BridgePattern.UnitTests
{
    [TestClass]
    public class InfraredRemoteControlSonyLedTVTests
    {
        [TestMethod]
        public void SwitchOn_ShouldOnTrue()
        {
            // Arrange
            InfraredRemoteControlSonyLedTV ledTV = new InfraredRemoteControlSonyLedTV();

            // Act
            ledTV.SwitchOn();

            //
            Assert.IsTrue(ledTV.IsSwitchOn);
        }

        [TestMethod]
        public void SwitchOn_ShouldOnFalse()
        {
            // Arrange
            InfraredRemoteControlSonyLedTV ledTV = new InfraredRemoteControlSonyLedTV();

            // Act
            ledTV.SwitchOff();

            //
            Assert.IsFalse(ledTV.IsSwitchOn);
        }

        [TestMethod]
        public void SetChannel_ShouldSetCurrentChannel()
        {
            // Arrange
            InfraredRemoteControlSonyLedTV ledTV = new InfraredRemoteControlSonyLedTV();

            // Act
            ledTV.SetChannel(10);

            //
            Assert.AreEqual(10, ledTV.SelectedChannel);
        }
    }
}
