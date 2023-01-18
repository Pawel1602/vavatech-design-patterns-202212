
using System.Runtime.InteropServices;
using FluentAssertions;
using Xunit;

namespace InterpreterPattern.UnitTests
{
    public class ParserTests
    {
        private readonly Parser parser;
        
        public ParserTests()
        {
            parser = new Parser(new ExpressionFactory());
        }
        
        [Theory]
        [InlineData("2 2 +", 4)]
        [InlineData("4 2 -", 2)]
        [InlineData("2 2 *", 4)]
        [InlineData("2 3 + 1 2 - *", -5)] // (2 + 3) * (1 - 2)
        [InlineData("5 1 2 + 4 * + 3 -", 14)] // 5 + (1+2) × 4 − 3
        public void Evaluate_ValidExpression_ShouldReturnResult(string expression, int expected)
        {
            // Act
            int result = parser.Evaluate(expression);

            // Assert
            result.Should().Be(expected);
        }
    }
}
