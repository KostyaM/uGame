using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseUtils
{
    public static Vector3 GetMouseWorldPosition() 
    {
        return GetAbsolutePointPosition(Input.mousePosition);
    }

    public static Vector3 GetAbsolutePointPosition(Vector3 point)
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(point);
        vec.z = 0f;
        return vec;
    }
   
}
