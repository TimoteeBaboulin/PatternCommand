using UnityEngine;

public class VerticalCommand : Command{
    private readonly float _axisValue;

    public VerticalCommand(float axisValue){
        _axisValue = axisValue;
    }

    public override void Do(Cube cube){
        _cube = cube;
        cube.transform.Translate(Vector3.forward * _axisValue * cube.Speed);
    }

    public override void Undo(){
        _cube.transform.Translate(-Vector3.forward * _axisValue * _cube.Speed);
    }
}