using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : MonoBehaviour
{
    public bool ShowBounds;
    public Bounds bounds;

    private void Start()
    {
        bounds = gameObject.GetComponent<Renderer>().bounds;
    }

    private void Update()
    {
        bounds = gameObject.GetComponent<Renderer>().bounds;
    }
    private void OnDrawGizmos()
    {
        bounds = gameObject.GetComponent<Renderer>().bounds;
        Gizmos.DrawCube(bounds.center, bounds.size);
    }
}
