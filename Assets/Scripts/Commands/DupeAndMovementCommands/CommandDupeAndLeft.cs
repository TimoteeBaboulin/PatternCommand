using System.Collections.Generic;
using Commands.MovementCommands;

namespace Commands.DupeAndMovementCommands{
    public class CommandDupeAndLeft : CommandCube{
        private readonly Stack<Command> _subCommands = new();

        public CommandDupeAndLeft(Cube context) : base(context){
        }

        public override void Do(){
            var forwardCommand = new CommandLeft(_context);
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