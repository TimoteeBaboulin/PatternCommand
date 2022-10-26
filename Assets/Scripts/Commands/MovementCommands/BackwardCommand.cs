using UnityEngine;

namespace Commands{
    public class CommandBackward : CommandCube{
        public CommandBackward(Cube context) : base(context){
        }

        public override void Do(){
            _context.transform.Translate(Vector3.back * _context.Speed);
        }

        public override void Undo(){
            _context.transform.Translate(Vector3.forward * _context.Speed);
        }
    }
}