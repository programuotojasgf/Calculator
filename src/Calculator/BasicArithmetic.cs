namespace Calculator;

public static class BasicArithmetic
{
    public static int Sum(int left, int right) => left + right;
    public static int Multiply(int left, int right) => left * right;
    public static double Divide(int left, int right)
    {
        if (right == 0)
            throw new DivideByZeroException("Cannot divide by zero.");
        
        return (double)left / right;
    }
}
