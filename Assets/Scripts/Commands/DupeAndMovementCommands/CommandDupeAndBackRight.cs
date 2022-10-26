using System.Collections.Generic;

namespace Commands.DupeAndMovementCommands{
    public class CommandDupeAndBackRight : CommandCube{
        private readonly Stack<Command> _subCommands = new();

        public CommandDupeAndBackRight(Cube context) : base(context){
        }

        public override void Do(){
            var backwardCommand = new CommandDupeAndBackward(_context);
            var rightCommand = new CommandDupeAndRight(_context);

            rightCommand.Do();
            _subCommands.Push(rightCommand);

            backwardCommand.Do();
            _subCommands.Push(backwardCommand);
        }

        public override void Undo(){
            foreach (var subCommand in _subCommands) subCommand.Undo();
        }
    }
}