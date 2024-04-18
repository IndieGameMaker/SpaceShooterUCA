using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmos : MonoBehaviour
{
    public Color color = Color.green;

    [Range(0.2f, 2.0f)]
    public float radius = 0.3f;

    void OnDrawGizmos()
    {
        Gizmos.color = this.color;
        Gizmos.DrawSphere(transform.position, this.radius);
    }
}
