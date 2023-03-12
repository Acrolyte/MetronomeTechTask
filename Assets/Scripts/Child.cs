using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
    public int index;
    public int unit;
    public char axis;
    private Child[] children;
    private void Start()
    {
        children = GameObject.Find("Generator").GetComponent<Generator>().children;
    }
}
