using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SingletonPattern.UnitTests
{
    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void Create_CallTwice_ShouldBeTheSameInstance()
        {
            // Arrange

            // Act
            MessageService messageService = new MessageService();
            PrintService printService = new PrintService();

            // Assert
            Assert.AreSame(messageService.logger, printService.logger, "Different instances");

        }
    }
}
