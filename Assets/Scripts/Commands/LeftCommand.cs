using UnityEngine;

public class CommandLeft : Command{
    
    public override void Do(Cube cube){
        _cube = cube;
        cube.transform.Translate(Vector3.left * cube.Speed);
    }

    public override void Undo(){
        _cube.transform.Translate(Vector3.right * _cube.Speed);
    }
}