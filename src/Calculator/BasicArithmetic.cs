namespace Calculator;

public static class BasicArithmetic
{
    public static decimal Sum(decimal left, decimal right) => checked(left + right);
    public static int Multiply(int left, int right) => left * right;
    public static decimal Divide(decimal left, decimal right) => left / right;
}
