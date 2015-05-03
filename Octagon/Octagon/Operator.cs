
namespace Octagon
{
    public class Operator<T>
    {
        public delegate T OperatorDelegate(params T[] operators);

        public byte Priority { get; set; }
        
        public OperatorDelegate OperatorFunction { get; set; }
    }
}
