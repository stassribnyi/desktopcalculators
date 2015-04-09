namespace Octagon.CalculatorCore
{
    public interface ITrigonometric<T> : IBase<T>
    {
        T Sin(params T[] value);
        T Cos(params T[] value);
        T Tan(params T[] value);
        T CTan(params T[] value);
        T ATan(params T[] value);
        T ASin(params T[] value);
        T ACos(params T[] value);
    }
}
