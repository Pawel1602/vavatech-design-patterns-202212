using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BridgePattern.UnitTests
{
    [TestClass]
    public class BlikZusTransferTests
    {
        [TestMethod]
        public void Test()
        {
            // Arrange
            ITransfer transfer = new ZusTransfer(1);
            PaymentType payment = new Blik(transfer);

            // Act
            payment.MakeTransfer();

            // Assert


        }
    }
}
