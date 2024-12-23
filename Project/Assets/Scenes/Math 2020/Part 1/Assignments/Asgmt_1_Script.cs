#if UNITY_EDITOR
    using UnityEditor;
#endif

using UnityEngine;

/*
 *-------------------------------------------------------------------------------------
 *  In this Assignment I have to recreate the radial trigger function from the 
 *  course on my own. 
 *-------------------------------------------------------------------------------------
 */


public class Asgmt_1_script : MonoBehaviour
{
    // Object I want to check
    public Transform obj;

    // Radius
    [Range(0f, 10f)]
    public float radius = 1f;

    #if UNITY_EDITOR
    private void OnDrawGizmos() {
        Vector2 origin = this.transform.position;
        Vector2 obj_trs = obj.transform.position;
        bool trigger = false;
        Handles.color = Color.red;

        // Distance Calculation
        float distance = Vector2.Distance(origin, obj_trs);

        trigger = distance <= radius;

        if (trigger) {
            Handles.color = Color.green;
        }

        Handles.DrawWireDisc(origin, new Vector3(0, 0, 1), radius);
    }
    #endif
}
