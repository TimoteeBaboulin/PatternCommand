using System.Collections.Generic;

namespace Commands{
    public class CommandDupeAndBackward : CommandCube{
        private readonly Stack<Command> _subCommands = new();

        public CommandDupeAndBackward(Cube context) : base(context){
        }

        public override void Do(){
            var forwardCommand = new CommandBackward(_context);
            var dupeCommand = new CommandDuplicateCube(_context);

            dupeCommand.Do();
            _subCommands.Push(dupeCommand);

            forwardCommand.Do();
            _subCommands.Push(forwardCommand);
        }

        public override void Undo(){
            foreach (var subCommand in _subCommands) subCommand.Undo();
        }
    }
}