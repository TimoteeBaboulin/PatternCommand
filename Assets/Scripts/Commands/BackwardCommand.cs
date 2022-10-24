using UnityEngine;

public class CommandBackward : Command{
    
    public override void Do(Cube cube){
        _cube = cube;
        cube.transform.Translate(Vector3.back * cube.Speed);
    }

    public override void Undo(){
        _cube.transform.Translate(Vector3.forward * _cube.Speed);
    }
}