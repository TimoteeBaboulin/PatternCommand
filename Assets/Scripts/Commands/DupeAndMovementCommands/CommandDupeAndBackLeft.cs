using System.Collections.Generic;

namespace Commands{
    public class CommandDupeAndBackLeft : CommandCube{
        private readonly Stack<Command> _subCommands = new();

        public CommandDupeAndBackLeft(Cube context) : base(context){
        }

        public override void Do(){
            var backwardCommand = new CommandDupeAndBackward(_context);
            var leftCommand = new CommandDupeAndLeft(_context);

            leftCommand.Do();
            _subCommands.Push(leftCommand);

            backwardCommand.Do();
            _subCommands.Push(backwardCommand);
        }

        public override void Undo(){
            foreach (var subCommand in _subCommands) subCommand.Undo();
        }
    }
}