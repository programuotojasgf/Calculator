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

    [Theory]
    [InlineData(int.MaxValue, 1, int.MaxValue)]
    [InlineData(1, int.MaxValue, int.MaxValue)]
    [InlineData(int.MinValue, 1, int.MinValue)]
    [InlineData(1, int.MinValue, int.MinValue)]
    [InlineData(int.MaxValue, -1, -int.MaxValue)]
    [InlineData(-1, int.MaxValue, -int.MaxValue)]
    public void Multiply_WithBoundaryValues_ReturnsExpected(int left, int right, int expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Multiply(left, right);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(int.MaxValue, 2)]
    [InlineData(2, int.MaxValue)]
    [InlineData(int.MinValue, 2)]
    [InlineData(2, int.MinValue)]
    [InlineData(int.MaxValue, int.MaxValue)]
    [InlineData(int.MinValue, int.MinValue)]
    [InlineData(int.MaxValue, int.MinValue)]
    public void Multiply_WithBoundaryValuesAndOverflow_HandlesOverflow(int left, int right)
    {
        // Arrange
        
        // Act & Assert
        // These will overflow but the method doesn't use checked arithmetic
        // so we expect them to wrap around without throwing
        var result = Calculator.BasicArithmetic.Multiply(left, right);
        
        // Just verify no exception is thrown and result is calculated
        result.Should().BeOfType(typeof(int));
    }
}
