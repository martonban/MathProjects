using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScriptVector : MonoBehaviour
{
    private void OnDrawGizmos() {

        Vector2 ptr = transform.position;
        float length = Mathf.Sqrt(Mathf.Pow(ptr.x, 2) + Mathf.Pow(ptr.y, 2));

        Gizmos.DrawLine(Vector2.zero , ptr/length);
    }
}
