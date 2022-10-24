using UnityEngine;

public class ColorChangeCommand : Command{
    private Color _color;

    public ColorChangeCommand(Color color){
        _color = color;
    }

    public override void Do(Cube cube){
        _cube = cube;
        cube.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }

    public override void Undo(){
        _cube.GetComponent<MeshRenderer>().material.color = _color;
    }
}