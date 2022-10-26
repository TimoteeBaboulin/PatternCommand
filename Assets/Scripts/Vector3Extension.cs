using UnityEngine;

public class Vector3Extension{
    public static Vector3 Copy(Vector3 toCopy){
        return new Vector3(toCopy.x, toCopy.y, toCopy.z);
    }
}