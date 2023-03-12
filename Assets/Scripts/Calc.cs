using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Calc 
{
    public static Bounds GetMaxBounds(GameObject parent)
    {
        var total = new Bounds(parent.transform.position, Vector3.zero);
        total = parent.GetComponent<Renderer>().bounds;
        Debug.Log($"{parent.gameObject.name}:::  X: {total.size.x}, Y: {total.size.y}, Z: {total.size.z}");
        return total;
    }


    public static Bounds GetRecalibratedBounds(GameObject parent, Bounds oldBounds)
    { 
        return parent.GetComponent<Renderer>().bounds;
    }

}
