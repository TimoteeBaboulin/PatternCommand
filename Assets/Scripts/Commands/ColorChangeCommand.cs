using UnityEngine;

namespace Commands{
    public class ColorChangeCommand : CommandCube{
        private Color _color;

        public ColorChangeCommand(Cube context, Color color) : base(context){
            _color = color;
        }

        public override void Do(){
            var color = _context.GetColor();
            _context.ChangeColor(_color);
            _color = color;
        }

        public override void Undo(){
            _context.ChangeColor(_color);
        }
    }
}