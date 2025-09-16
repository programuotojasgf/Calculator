using FluentAssertions;

namespace Calculator.Tests.BasicArithmeticNS;

public class DivideTests
{
    [Theory]
    [InlineData(10, 2, 5.0)]
    [InlineData(15, 3, 5.0)]
    [InlineData(20, 4, 5.0)]
    [InlineData(100, 10, 10.0)]
    public void Divide_WithWholeNumberResults_ReturnsExpected(int left, int right, double expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Divide(left, right);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(10, 3, 3.3333333333333335)]
    [InlineData(7, 2, 3.5)]
    [InlineData(22, 7, 3.142857142857143)]
    [InlineData(1, 3, 0.3333333333333333)]
    [InlineData(5, 4, 1.25)]
    public void Divide_WithDecimalResults_ReturnsExpected(int left, int right, double expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Divide(left, right);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, 1, 0.0)]
    [InlineData(0, 5, 0.0)]
    [InlineData(0, 100, 0.0)]
    [InlineData(0, -3, 0.0)]
    [InlineData(0, int.MaxValue, 0.0)]
    [InlineData(0, int.MinValue, 0.0)]
    public void Divide_WithZeroDividend_ReturnsZero(int left, int right, double expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Divide(left, right);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(10, -2, -5.0)]
    [InlineData(-10, 2, -5.0)]
    [InlineData(-10, -2, 5.0)]
    [InlineData(-15, 3, -5.0)]
    [InlineData(15, -3, -5.0)]
    [InlineData(-15, -3, 5.0)]
    public void Divide_WithNegativeNumbers_ReturnsExpected(int left, int right, double expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Divide(left, right);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(int.MaxValue, 1, 2147483647.0)]
    [InlineData(int.MaxValue, -1, -2147483647.0)]
    [InlineData(int.MinValue, 1, -2147483648.0)]
    [InlineData(int.MinValue, -1, 2147483648.0)]
    [InlineData(int.MaxValue, int.MaxValue, 1.0)]
    [InlineData(int.MinValue, int.MinValue, 1.0)]
    [InlineData(int.MaxValue, 2, 1073741823.5)]
    [InlineData(int.MinValue, 2, -1073741824.0)]
    public void Divide_WithBoundaryValues_ReturnsExpected(int left, int right, double expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Divide(left, right);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(-1)]
    [InlineData(100)]
    [InlineData(-100)]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    public void Divide_ByZero_ThrowsDivideByZeroException(int dividend)
    {
        // Arrange
        const int divisor = 0;
        
        // Act
        var act = () => Calculator.BasicArithmetic.Divide(dividend, divisor);

        // Assert
        act.Should().Throw<DivideByZeroException>()
           .WithMessage("Cannot divide by zero.");
    }

    [Theory]
    [InlineData(1, 1000000, 0.000001)]
    [InlineData(1, 10000, 0.0001)]
    [InlineData(1, 1000, 0.001)]
    [InlineData(999999, 1000000, 0.999999)]
    [InlineData(1, 7, 0.14285714285714285)]
    public void Divide_WithSmallResults_ReturnsExpected(int left, int right, double expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Divide(left, right);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(1000000, 1, 1000000.0)]
    [InlineData(int.MaxValue, 10, 214748364.7)]
    [InlineData(int.MinValue, 10, -214748364.8)]
    [InlineData(1000000, 3, 333333.3333333333)]
    public void Divide_WithLargeResults_ReturnsExpected(int left, int right, double expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Divide(left, right);

        // Assert
        result.Should().Be(expected);
    }
}