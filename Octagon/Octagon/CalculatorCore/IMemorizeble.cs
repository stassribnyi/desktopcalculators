namespace Octagon.CalculatorCore
{
    public interface IMemorizeble<T>
    {
        T Memory { get; set; }
        void MemoryPlus(T value);
        void MemoryMinus(T value);
        void MemoryClear();        
    }
}
