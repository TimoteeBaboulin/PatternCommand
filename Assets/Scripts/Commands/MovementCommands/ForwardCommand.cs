using UnityEngine;

namespace Commands{
    public class CommandForward : CommandCube{
        public CommandForward(Cube context) : base(context){
        }

        public override void Do(){
            _context.transform.Translate(Vector3.forward * _context.Speed);
        }

        public override void Undo(){
            _context.transform.Translate(Vector3.back * _context.Speed);
        }
    }
}