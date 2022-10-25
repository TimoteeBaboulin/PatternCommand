using UnityEngine;

public class CommandRight : CommandCube{
    
    public override void Do(){
        _context.transform.Translate(Vector3.right * _context.Speed);
    }

    public override void Undo(){
        _context.transform.Translate(Vector3.left * _context.Speed);
    }

    public CommandRight(Cube context) : base(context){
    }
}