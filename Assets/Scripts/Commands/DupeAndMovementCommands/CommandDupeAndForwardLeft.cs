using System.Collections.Generic;

namespace Commands{
    public class CommandDupeAndForwardLeft : CommandCube{
        private readonly Stack<Command> _subCommands = new();

        public CommandDupeAndForwardLeft(Cube context) : base(context){
        }

        public override void Do(){
            var forwardCommand = new CommandDupeAndForward(_context);
            var leftCommand = new CommandDupeAndLeft(_context);

            leftCommand.Do();
            _subCommands.Push(leftCommand);

            forwardCommand.Do();
            _subCommands.Push(forwardCommand);
        }

        public override void Undo(){
            foreach (var subCommand in _subCommands) subCommand.Undo();
        }
    }
}