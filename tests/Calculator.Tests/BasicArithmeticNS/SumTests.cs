using FluentAssertions;

namespace Calculator.Tests.BasicArithmeticNS;

public class SumTests
{
    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 2, 4)]
    public void Sum_WithPositiveNumbers_ReturnsExpected(decimal left, decimal right, decimal expected)
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
    public void Sum_WithZeroValues_ReturnsExpected(decimal left, decimal right, decimal expected)
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
    public void Sum_WithNegativeNumbers_ReturnsExpected(decimal left, decimal right, decimal expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Sum(left, right);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(2147483647, 0, 2147483647)] // int.MaxValue equivalent
    [InlineData(0, 2147483647, 2147483647)]
    [InlineData(-2147483648, 0, -2147483648)] // int.MinValue equivalent
    [InlineData(0, -2147483648, -2147483648)]
    [InlineData(2147483647, -2147483648, -1)]
    [InlineData(-2147483648, 2147483647, -1)]
    [InlineData(1073741823, 1073741824, 2147483647)] // MaxValue/2 + MaxValue/2 + 1
    public void Sum_WithBoundaryValues_ReturnsExpected(decimal left, decimal right, decimal expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Sum(left, right);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Sum_WithMaxValuePlusOne_ThrowsOverflowException()
    {
        // Arrange
        var maxValue = decimal.MaxValue;
        const decimal one = 1m;
        
        // Act
        var action = () => Calculator.BasicArithmetic.Sum(maxValue, one);
        
        // Assert
        action.Should().Throw<OverflowException>();
    }
    
    [Fact] 
    public void Sum_WithMinValueMinusOne_ThrowsOverflowException()
    {
        // Arrange
        var minValue = decimal.MinValue;
        const decimal minusOne = -1m;
        
        // Act
        var action = () => Calculator.BasicArithmetic.Sum(minValue, minusOne);
        
        // Assert
        action.Should().Throw<OverflowException>();
    }
    
    [Fact]
    public void Sum_WithTwoMaxValues_ThrowsOverflowException()
    {
        // Arrange
        var maxValue = decimal.MaxValue;
        
        // Act
        var action = () => Calculator.BasicArithmetic.Sum(maxValue, maxValue);
        
        // Assert
        action.Should().Throw<OverflowException>();
    }
    
    [Fact]
    public void Sum_WithTwoMinValues_ThrowsOverflowException()
    {
        // Arrange
        var minValue = decimal.MinValue;
        
        // Act
        var action = () => Calculator.BasicArithmetic.Sum(minValue, minValue);
        
        // Assert
        action.Should().Throw<OverflowException>();
    }

    [Theory]
    [InlineData(0.1, 0.2, 0.3)]
    [InlineData(1.5, 2.5, 4.0)]
    [InlineData(123.456, 789.012, 912.468)]
    [InlineData(0.000001, 0.000002, 0.000003)]
    [InlineData(999999.999999, 0.000001, 1000000.000000)]
    public void Sum_WithDecimalValues_ReturnsExpected(decimal left, decimal right, decimal expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Sum(left, right);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(-0.5, 0.5, 0.0)]
    [InlineData(-123.456, 123.456, 0.0)]
    [InlineData(1.1, -0.1, 1.0)]
    [InlineData(-999.999, 1000.001, 0.002)]
    public void Sum_WithPositiveAndNegativeDecimals_ReturnsExpected(decimal left, decimal right, decimal expected)
    {
        // Arrange
        
        // Act
        var result = Calculator.BasicArithmetic.Sum(left, right);

        // Assert
        result.Should().Be(expected);
    }
}
