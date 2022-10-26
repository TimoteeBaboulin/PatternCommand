using System.Collections.Generic;
using UnityEngine;

namespace Commands{
    public class CommandAddCube : CommandManager{
        private readonly Cube _cube;
        private readonly Stack<Command> _commands = new();

        public CommandAddCube(Manager context, Cube cube) : base(context){
            _cube = cube;
        }

        public override void Do(){
            if (!_context.CurrentCube.Contains(_cube) && _cube != null){
                _context.CurrentCube.Add(_cube);
                if (_cube.GetColor() == Color.black){
                    var command = new ColorChangeCommand(_cube, Color.red);
                    command.Do();
                    _commands.Push(command);
                }
            }
        }

        public override void Undo(){
            _context.CurrentCube.Remove(_cube);
            foreach (var command in _commands) command.Undo();
        }
    }
}