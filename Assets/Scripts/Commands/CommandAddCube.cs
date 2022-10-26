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
            if (_cube != null){
                //Si le cube existe deja dans la liste, enleve le a la place
                if (_context.CurrentCube.Contains(_cube)){
                    _context.CurrentCube.Remove(_cube);
                    if (_cube.GetColor()==Color.red) 
                        ChangeCubeColor(_cube, Color.black);
                    return;
                }
                
                _context.CurrentCube.Add(_cube);
                if (_cube.GetColor() == Color.black){
                    ChangeCubeColor(_cube, Color.red);
                }
            }
        }

        public override void Undo(){
            if (_context.CurrentCube.Contains(_cube)) _context.CurrentCube.Remove(_cube);
            else _context.CurrentCube.Add(_cube);
            foreach (var command in _commands) command.Undo();
        }

        private void ChangeCubeColor(Cube cube, Color color){
            var command = new ColorChangeCommand(cube, color);
            command.Do();
            _commands.Push(command);
        }
    }
}