using FluentAssertions;

namespace Calculator.Tests.BasicArithmeticNS;

public class SumTests
{
    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 2, 4)]
    public void Sum_WithPositiveNumbers_ReturnsExpected(int left, int right, int expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Sum(left, right);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(0, 5, 5)]
    [InlineData(10, 0, 10)]
    [InlineData(0, -3, -3)]
    [InlineData(-7, 0, -7)]
    public void Sum_WithZeroValues_ReturnsExpected(int left, int right, int expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Sum(left, right);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(-1, -1, -2)]
    [InlineData(-5, -10, -15)]
    [InlineData(5, -3, 2)]
    [InlineData(-8, 12, 4)]
    [InlineData(-100, -200, -300)]
    public void Sum_WithNegativeNumbers_ReturnsExpected(int left, int right, int expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Sum(left, right);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(int.MaxValue, 0, int.MaxValue)]
    [InlineData(0, int.MaxValue, int.MaxValue)]
    [InlineData(int.MinValue, 0, int.MinValue)]
    [InlineData(0, int.MinValue, int.MinValue)]
    [InlineData(int.MaxValue, int.MinValue, -1)]
    [InlineData(int.MinValue, int.MaxValue, -1)]
    [InlineData(1073741823, 1073741824, int.MaxValue)] // MaxValue/2 + MaxValue/2 + 1
    public void Sum_WithBoundaryValues_ReturnsExpected(int left, int right, int expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Sum(left, right);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(int.MaxValue, 1)]
    [InlineData(int.MinValue, -1)]
    [InlineData(int.MaxValue, int.MaxValue)]
    [InlineData(int.MinValue, int.MinValue)]
    [InlineData(2000000000, 2000000000)]
    public void Sum_WithOverflowConditions_ThrowsOverflowException(int left, int right)
    {
        // Arrange
        
        // Act
        var action = () => Calculator.BasicArithmetic.Sum(left, right);
        
        // Assert
        action.Should().Throw<OverflowException>();
    }
}
