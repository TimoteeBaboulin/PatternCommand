using UnityEngine;

public class CommandForward : Command{
    
    public override void Do(Cube cube){
        _cube = cube;
        cube.transform.Translate(Vector3.forward * cube.Speed);
    }

    public override void Undo(){
        _cube.transform.Translate(Vector3.back * _cube.Speed);
    }
}