using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScriptVector : MonoBehaviour
{
    public Transform aTf;
    public Transform bTf;

    public float abDist;

    private void OnDrawGizmos() {

        Vector2 a = aTf.position;
        Vector2 b = bTf.position;

        Gizmos.DrawLine(a, b);

        abDist = Vector2.Distance(a, b);

        // Math Way to normalize a vector
        //Vector2 ptr = transform.position;
        //float length = Mathf.Sqrt(Mathf.Pow(ptr.x, 2) + Mathf.Pow(ptr.y, 2));

        //Gizmos.DrawLine(Vector2.zero , ptr/length);

        // Unity Way 
        Vector2 ptr = transform.position;
        Vector2 dirToPoint = ptr / ptr.magnitude;
        Gizmos.DrawLine (Vector2.zero, dirToPoint);

    }
}
