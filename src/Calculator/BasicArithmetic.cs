namespace Calculator;

public static class BasicArithmetic
{
    public static int Sum(int left, int right) => checked(left + right);
    public static int Multiply(int left, int right) => left * right;
}
