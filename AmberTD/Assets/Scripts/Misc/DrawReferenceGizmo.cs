using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawReferenceGizmo : MonoBehaviour
{
    [SerializeField]
    private float radius;

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }
}
