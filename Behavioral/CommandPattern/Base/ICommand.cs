namespace Behavioral.CommandPattern.Base
{
    public interface ICommand
    {
         void Execute();
         bool CanExecute();
         void Undo();
         bool CanUndo();
    }
}