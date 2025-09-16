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

    [Fact]
    public void Sum_WithMaxValueAndVerySmallDecimal_DoesNotOverflow()
    {
        // Arrange - decimal.MaxValue has room for very small fractional additions
        var maxValue = decimal.MaxValue;
        const decimal verySmallDecimal = 0.000000000000000000000000001m;
        
        // Act & Assert - this should NOT overflow as decimal.MaxValue has precision for this
        var result = Calculator.BasicArithmetic.Sum(maxValue, verySmallDecimal);
        result.Should().Be(maxValue + verySmallDecimal);
    }

    [Fact] 
    public void Sum_WithMinValueAndVerySmallNegativeDecimal_DoesNotOverflow()
    {
        // Arrange - decimal.MinValue has room for very small fractional subtractions
        var minValue = decimal.MinValue;
        const decimal verySmallNegativeDecimal = -0.000000000000000000000000001m;
        
        // Act & Assert - this should NOT overflow
        var result = Calculator.BasicArithmetic.Sum(minValue, verySmallNegativeDecimal);
        result.Should().Be(minValue + verySmallNegativeDecimal);
    }

    [Fact]
    public void Sum_WithTwoLargePositiveValues_ThrowsOverflowException()
    {
        // Arrange - Use half of MaxValue for each operand to ensure overflow
        var largeValue1 = decimal.MaxValue / 2 + 1;
        var largeValue2 = decimal.MaxValue / 2 + 1;
        
        // Act
        var action = () => Calculator.BasicArithmetic.Sum(largeValue1, largeValue2);
        
        // Assert
        action.Should().Throw<OverflowException>();
    }

    [Fact]
    public void Sum_WithTwoLargeNegativeValues_ThrowsOverflowException()
    {
        // Arrange - Use half of MinValue for each operand to ensure overflow
        var largeNegValue1 = decimal.MinValue / 2 - 1;
        var largeNegValue2 = decimal.MinValue / 2 - 1;
        
        // Act
        var action = () => Calculator.BasicArithmetic.Sum(largeNegValue1, largeNegValue2);
        
        // Assert
        action.Should().Throw<OverflowException>();
    }

    [Fact]
    public void Sum_WithNearMaxValueAndSmallPositive_ThrowsOverflowException()
    {
        // Arrange - Use a value very close to MaxValue and add a small positive
        var nearMaxValue = decimal.MaxValue - 1;
        const decimal smallPositive = 2m;
        
        // Act
        var action = () => Calculator.BasicArithmetic.Sum(nearMaxValue, smallPositive);
        
        // Assert
        action.Should().Throw<OverflowException>();
    }

    [Fact]
    public void Sum_WithNearMinValueAndSmallNegative_ThrowsOverflowException()
    {
        // Arrange - Use a value very close to MinValue and add a small negative
        var nearMinValue = decimal.MinValue + 1;
        const decimal smallNegative = -2m;
        
        // Act
        var action = () => Calculator.BasicArithmetic.Sum(nearMinValue, smallNegative);
        
        // Assert
        action.Should().Throw<OverflowException>();
    }

    [Fact]
    public void Sum_WithLargePositiveAndNegative_DoesNotThrowOverflow()
    {
        // Arrange
        const decimal largePositive = 1000000000m;
        const decimal moderateNegative = -500000000m;
        const decimal expected = 500000000m;
        
        // Act
        var result = Calculator.BasicArithmetic.Sum(largePositive, moderateNegative);
        
        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Sum_WithLargeNegativeAndPositive_DoesNotThrowOverflow()
    {
        // Arrange
        const decimal largeNegative = -1000000000m;
        const decimal moderatePositive = 500000000m;
        const decimal expected = -500000000m;
        
        // Act
        var result = Calculator.BasicArithmetic.Sum(largeNegative, moderatePositive);
        
        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Sum_WithVeryLargeMixedValues_DoesNotThrowOverflow()
    {
        // Arrange - Use runtime calculation for very large values
        var largePositive = decimal.MaxValue / 4;
        var largeNegative = -(decimal.MaxValue / 4) + 1;
        var expected = 1m;
        
        // Act
        var result = Calculator.BasicArithmetic.Sum(largePositive, largeNegative);
        
        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Sum_WithMaxValueAndZero_ReturnsMaxValue()
    {
        // Arrange
        var maxValue = decimal.MaxValue;
        const decimal zero = 0m;
        
        // Act
        var result = Calculator.BasicArithmetic.Sum(maxValue, zero);
        
        // Assert
        result.Should().Be(maxValue);
    }

    [Fact]
    public void Sum_WithMinValueAndZero_ReturnsMinValue()
    {
        // Arrange
        var minValue = decimal.MinValue;
        const decimal zero = 0m;
        
        // Act
        var result = Calculator.BasicArithmetic.Sum(minValue, zero);
        
        // Assert
        result.Should().Be(minValue);
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
