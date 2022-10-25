using UnityEngine;

public class CommandBackward : CommandCube{
    
    public override void Do(){
        _context.transform.Translate(Vector3.back * _context.Speed);
    }

    public override void Undo(){
        _context.transform.Translate(Vector3.forward * _context.Speed);
    }

    public CommandBackward(Cube context) : base(context){
    }
}