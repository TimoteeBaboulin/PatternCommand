using UnityEngine;

namespace Commands{
    public class CommandDuplicateCube : CommandCube{
        public CommandDuplicateCube(Cube context) : base(context){
        }

        public override void Do(){
            var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject.AddComponent<BoxCollider>();
            gameObject.transform.position = Vector3Extension.Copy(_context.transform.position);
            _context = gameObject.AddComponent<Cube>();
            _context.ChangeColor(Color.black);
        }

        public override void Undo(){
            Object.Destroy(_context.gameObject);
        }
    }
}