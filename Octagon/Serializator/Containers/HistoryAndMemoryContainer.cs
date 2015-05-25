using System;
using Command_Calc.Model;
using Octagon;

namespace Serializator.Containers
{
    [Serializable]

    public class HistoryAndMemoryContainer
    {
        public CalcMemory CalcMemory { get; set; }
        public HistoryInvoker HistoryInvoker { get; set; }         
    }
}
