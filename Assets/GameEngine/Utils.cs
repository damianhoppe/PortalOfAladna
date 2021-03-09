using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static Vector3 copy(Vector3 vec)
    {
        return new Vector3(vec.x, vec.y, vec.z);
    }

    public static Vector3 copyZ(Vector3 vec, float z)
    {
        return new Vector3(vec.x, vec.y, z);
    }
}
