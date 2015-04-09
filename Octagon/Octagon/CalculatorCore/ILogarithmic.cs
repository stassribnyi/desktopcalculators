namespace Octagon.CalculatorCore
{
    public interface ILogarithmic<T> : IBase<T>
    {
        T Exp(params T[] value);
        T Ln(params T[] value);
        T Log(params T[] value);
        T Fact(params T[] value);
    }
}
