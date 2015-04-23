using Octagon.CalculatorCore;

namespace Octagon
{
    public class CalcMemory : IMemorizeble<double>
    {
        private double _memory;

        public CalcMemory()
        {
            _memory = 0;
        }

        public double Memory
        {
            get { return _memory; }
            set { _memory = value; }
        }

        public void MemoryPlus(double value)
        {
            _memory += value;
        }

        public void MemoryMinus(double value)
        {
            _memory -= value;
        }

        public void MemoryClear()
        {
            _memory = 0;
        }

    }
}
