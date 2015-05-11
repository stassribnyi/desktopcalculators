namespace Command_Calc.Command
{
    //base command
    public abstract class BaseCommand
    {
        public abstract void Redo();
        public abstract void Undo();
    }
}
