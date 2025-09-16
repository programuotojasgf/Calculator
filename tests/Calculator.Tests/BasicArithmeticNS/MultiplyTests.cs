using FluentAssertions;

namespace Calculator.Tests.BasicArithmeticNS;

public class MultiplyTests
{
    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(4, 5, 20)]
    [InlineData(0, 5, 0)]
    [InlineData(-2, 3, -6)]
    [InlineData(-2, -3, 6)]
    public void Multiply_ReturnsExpected(int left, int right, int expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Multiply(left, right);

        // Assert
        result.Should().Be(expected);
    }
}
