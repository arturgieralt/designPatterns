using System.Collections.Generic;

namespace Behavioral.CommandPattern.Base
{
    public abstract class CommandManager
    {
        protected Stack<ICommand> commands = new Stack<ICommand>();

        public virtual bool Execute(ICommand command)
        {
            var canExecute = command.CanExecute();
            if(canExecute)
            {
                command.Execute();
                commands.Push(command);
            }
            return canExecute;
        }

        public virtual ICommand UndoLast()
        {
            if(commands.Count > 0) {
                var command = commands.Pop();

                if(command.CanUndo())
                {
                    // this could be better
                    command.Undo();
                }
                return command;
            }
            return null;
        }

        public virtual IEnumerable<ICommand> UndoAll()
        {
            var undoneCommands = new List<ICommand>();
            while(commands.Count > 0)
            {
                var command = commands.Pop();

                if(command.CanUndo())
                {
                    command.Undo();
                    // should it be flagged somehow it was done? Wrapped? CommandWithStatus object?
                }

                undoneCommands.Add(command);
            }
            return undoneCommands;
        }
        
    }
}