using FluentAssertions;

namespace Calculator.Tests.BasicArithmeticNS;

public class SumTests
{
    [Fact]
    public void OnePlusOne_ReturnsTwo()
    {
        // Arrange
        const int left = 1;
        const int right = 1;

        // Act
        var result = Calculator.BasicArithmetic.Sum(left, right);

        // Assert
        result.Should().Be(2);
    }
}
