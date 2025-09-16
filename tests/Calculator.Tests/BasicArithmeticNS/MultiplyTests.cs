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

    [Theory]
    [InlineData(5, 1, 5)]
    [InlineData(-5, 1, -5)]
    [InlineData(1, 5, 5)]
    [InlineData(1, -5, -5)]
    [InlineData(100, 1, 100)]
    [InlineData(-100, 1, -100)]
    public void Multiply_ByOne_ReturnsSameValue(int left, int right, int expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Multiply(left, right);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(0, 100, 0)]
    [InlineData(100, 0, 0)]
    [InlineData(0, -100, 0)]
    [InlineData(-100, 0, 0)]
    [InlineData(0, int.MaxValue, 0)]
    [InlineData(int.MaxValue, 0, 0)]
    [InlineData(0, int.MinValue, 0)]
    [InlineData(int.MinValue, 0, 0)]
    public void Multiply_ByZero_ReturnsZero(int left, int right, int expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Multiply(left, right);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(5, -1, -5)]
    [InlineData(-5, -1, 5)]
    [InlineData(100, -1, -100)]
    [InlineData(-100, -1, 100)]
    public void Multiply_ByNegativeOne_ReturnsNegatedValue(int left, int right, int expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Multiply(left, right);

        // Assert
        result.Should().Be(expected);
    }
}
