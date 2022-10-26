using UnityEngine;

namespace Commands{
    public class VerticalCommand : CommandCube{
        private readonly float _axisValue;

        public VerticalCommand(Cube context, float axisValue) : base(context){
            _axisValue = axisValue;
        }

        public override void Do(){
            _context.transform.Translate(Vector3.forward * _axisValue * _context.Speed);
        }

        public override void Undo(){
            _context.transform.Translate(-Vector3.forward * _axisValue * _context.Speed);
        }
    }
}