﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public static Object loadPrefabFromFile(string path)
    {
        Object loadedObject = Resources.Load(path);
        if (loadedObject == null)
            Debug.Log("LoadingPrefab - Error: File Not Found: " + path);
        return loadedObject;
    }
    public static GameObject getChildGameObject(Transform transf, string withName)
    {
        foreach (Transform transform in transf)
        {
            if (transform.gameObject.name == withName)
                return transform.gameObject;
            else
            {
                GameObject result = getChildGameObject(transform, withName);
                if (result != null)
                    return result;
            }
        }
        return null;
    }
}
