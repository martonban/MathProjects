using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif

public class RadialTriggerScript : MonoBehaviour {
    public Transform objTest;
    public bool triggered;

    [Range(0f, 4f)]
    public float radius = 1f;

    #if UNITY_EDITOR
    private void OnDrawGizmos() {
        Vector2 origin = transform.position;
        Vector2 obj_trans = objTest.transform.position;

        // This is a pretty expensive way to do it
        float distance = Vector2.Distance(obj_trans, origin);

        if (radius <= distance) {
            triggered = false;
            Handles.color = Color.red;
        } else {
            triggered = true;
            Handles.color = Color.green;
        }

        // You can do this trigger function cheaper:
        // Note this is not a good way to calculate distance. USE THIS ONLY WHEN YOU WANT TO CHECK IS THE VECTOR IN A CERTAIN THRESHOLD!!
        Vector2 displacement = obj_trans - origin;
        float distance2 = displacement.x * displacement.x + displacement.y * displacement.y;

        bool isInside = distance2 < radius * radius;

        // In Unity we have a build in function for it
        float distance3 = Vector2.SqrMagnitude(obj_trans - origin);

        // Draw Disk
        Handles.DrawWireDisc(origin, new Vector3(0,0,1), radius);

    }
    #endif
}
