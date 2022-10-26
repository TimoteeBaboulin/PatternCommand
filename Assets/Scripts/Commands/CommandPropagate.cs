using System.Collections.Generic;
using UnityEngine;

namespace Commands{
    public class CommandPropagate<T> : CommandManager where T : CommandCube{
        private readonly Stack<T> _commands = new();

        public CommandPropagate(Manager context) : base(context){
        }

        public override void Do(){
            if (typeof(T) == typeof(ColorChangeCommand)){
                var color = Random.ColorHSV();
                foreach (var cube in _context.CurrentCube){
                    var commandType = typeof(T);
                    var commandConstructor = commandType.GetConstructor(new[]{typeof(Cube), typeof(Color)});
                    var command = (T) commandConstructor.Invoke(new object[]{cube, color});
                    command.Do();
                    _commands.Push(command);
                }

                return;
            }

            foreach (var cube in _context.CurrentCube){
                var commandType = typeof(T);
                var commandConstructor = commandType.GetConstructor(new[]{typeof(Cube)});
                var command = (T) commandConstructor.Invoke(new object[]{cube});
                command.Do();
                _commands.Push(command);
            }
        }

        public override void Undo(){
            foreach (var command in _commands) command.Undo();
        }
    }
}