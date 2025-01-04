using UnityEngine;
using UnityEditor;

public class CrossProductScript : MonoBehaviour
{
    private void OnDrawGizmos() {
        Vector3 headPos = transform.position;
        Vector3 lookDir = transform.forward;

        void DrawRay (Vector3 p, Vector3 dir) => Handles.DrawAAPolyLine(p, p + dir);

        if (Physics.Raycast(headPos, transform.forward, out RaycastHit hit)) {
            Vector3 hitPos = hit.point;
            Vector3 normal = hit.normal;
            Vector3 right = Vector3.Cross(lookDir, normal).normalized;
            Vector3 forward = Vector3.Cross(right, normal);

            // Visualize hit ray
            Handles.color = Color.white;
            Handles.DrawAAPolyLine(headPos, hitPos);

            // Visualize surface normal vector
            Handles.color = Color.green;
            DrawRay(hitPos, right);

            // Visualize right vector
            Handles.color = Color.red;
            DrawRay(hitPos, normal);

            // Visualize forward vector
            Handles.color = Color.cyan;
            DrawRay(hitPos, forward);
        } else {
            Handles.color = Color.red;
            DrawRay(headPos, lookDir);
        }
    }
}
