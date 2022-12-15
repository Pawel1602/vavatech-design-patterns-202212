using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterpreterPattern.UnitTests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void Evaluate_ValidExpression_ShouldReturnResult()
        {
            // Arrange
            string expression = "2 3 + 1 - 2 *"; // (2 + 3) * (1 - 2) = -5

            var parser = new Parser();

            // Act
            int result = parser.Evaluate(expression);

            // Assert
            Assert.AreEqual(-5, result);

        }
    }
}
