using System;

namespace Command_Calc.Command
{
    //base command
    [Serializable]
    public abstract class BaseCommand
    {
        public abstract void Redo();
        public abstract void Undo();
    }
}
