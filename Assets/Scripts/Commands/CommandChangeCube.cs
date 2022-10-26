using System.Collections.Generic;
using UnityEngine;

namespace Commands{
    public class CommandChangeCube : CommandManager{
        private List<Cube> _cube;
        private readonly Stack<CommandCube> _subCommands = new();

        public CommandChangeCube(Manager context, Cube cube) : base(context){
            _cube = new List<Cube>{cube};
        }

        public override void Do(){
            //Change color of previously selected cube
            foreach (var cube in _context.CurrentCube){
                if (cube.GetColor() != Color.red) continue;
                var command = new ColorChangeCommand(cube, Color.black);
                command.Do();
                _subCommands.Push(command);
            }

            var oldList = _context.CurrentCube;
            _context.CurrentCube.Clear();
            _context.CurrentCube = _cube;

            if (_cube[0].GetColor() == Color.black){
                var colorCommand = new ColorChangeCommand(_cube[0], Color.red);
                colorCommand.Do();
                _subCommands.Push(colorCommand);
            }

            _cube = oldList;
        }

        public override void Undo(){
            foreach (var command in _subCommands) command.Undo();
            _context.CurrentCube = _cube;
        }
    }
}