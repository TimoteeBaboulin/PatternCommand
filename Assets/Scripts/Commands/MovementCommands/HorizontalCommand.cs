using UnityEngine;

namespace Commands{
    public class HorizontalCommand : CommandCube{
        private readonly float _axisValue;

        public HorizontalCommand(Cube context, float axisValue) : base(context){
            _axisValue = axisValue;
        }

        public override void Do(){
            _context.transform.Translate(Vector3.right * _axisValue * _context.Speed);
        }

        public override void Undo(){
            _context.transform.Translate(-Vector3.right * _axisValue * _context.Speed);
        }
    }
}