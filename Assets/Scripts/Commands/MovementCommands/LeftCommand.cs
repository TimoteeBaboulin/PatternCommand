using UnityEngine;

namespace Commands.MovementCommands{
    public class CommandLeft : CommandCube{
        public CommandLeft(Cube context) : base(context){
        }

        public override void Do(){
            _context.transform.Translate(Vector3.left * _context.Speed);
        }

        public override void Undo(){
            _context.transform.Translate(Vector3.right * _context.Speed);
        }
    }
}