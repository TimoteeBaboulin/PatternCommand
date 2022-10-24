using TMPro;
using UnityEngine;

public class HorizontalCommand : Command{
    private readonly float _axisValue;

    public HorizontalCommand(float axisValue){
        _axisValue = axisValue;
    }

    public override void Do(Cube cube){
        cube.transform.Translate(Vector3.right * _axisValue * cube.Speed);
    }

    public override void Undo(){
        _cube.transform.Translate(-Vector3.right * _axisValue * _cube.Speed);
    }
}