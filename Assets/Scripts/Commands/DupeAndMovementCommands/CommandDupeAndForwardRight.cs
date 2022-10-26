using System.Collections.Generic;

namespace Commands.DupeAndMovementCommands{
    public class CommandDupeAndForwardRight : CommandCube{
        private readonly Stack<Command> _subCommands = new();

        public CommandDupeAndForwardRight(Cube context) : base(context){
        }

        public override void Do(){
            var forwardCommand = new CommandDupeAndForward(_context);
            var rightCommand = new CommandDupeAndRight(_context);

            rightCommand.Do();
            _subCommands.Push(rightCommand);

            forwardCommand.Do();
            _subCommands.Push(forwardCommand);
        }

        public override void Undo(){
            foreach (var subCommand in _subCommands) subCommand.Undo();
        }
    }
}