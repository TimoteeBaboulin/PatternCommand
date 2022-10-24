using UnityEngine;

public class CommandRight : Command{
    
    public override void Do(Cube cube){
        _cube = cube;
        cube.transform.Translate(Vector3.right * cube.Speed);
    }

    public override void Undo(){
        _cube.transform.Translate(Vector3.left * _cube.Speed);
    }
}