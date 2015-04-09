namespace Octagon.CalculatorCore
{
    public interface IBase<T>
    {
        T Addition(params T[] values);
        T Subtraction(params T[] values);
        T Multiplication(params T[] values);
        T Division(params T[] values);
        T Power(params T[] values);
    }
}
