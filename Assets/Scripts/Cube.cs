using UnityEngine;

public class Cube : MonoBehaviour{
    public int Speed;

    public void ChangeColor(Color color){
        GetComponent<MeshRenderer>().material.color = color;
    }
    public Color GetColor(){
        return GetComponent<MeshRenderer>().material.color;
    }
}