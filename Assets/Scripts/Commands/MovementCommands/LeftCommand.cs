using UnityEngine;

public class CommandLeft : CommandCube{
    
    public override void Do(){
        _context.transform.Translate(Vector3.left * _context.Speed);
    }

    public override void Undo(){
        _context.transform.Translate(Vector3.right * _context.Speed);
    }

    public CommandLeft(Cube context) : base(context){
    }
}