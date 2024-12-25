using UnityEngine;

public class Asg3_Script : MonoBehaviour
{

    //public Vector2 localSapacePoint;

    public Transform localObjTransform;
    public Vector2 worldSapcePoint;

    private void OnDrawGizmos() {
        Vector2 objPos = transform.position;
        Vector2 right = transform.right;
        Vector2 up = transform.up;

        Vector2 LocalToWorld(Vector2 localPt) {
            Vector2 worldOffset = right * localPt.x + up * localPt.y;
            return (Vector2)transform.position + worldOffset;
        }

        Vector2 WorldToLocal(Vector2 worldPt) {
            Vector2 relativePoint = worldPt - objPos;

            float x = Vector2.Dot(relativePoint, right);
            float y = Vector2.Dot(relativePoint, up);

            return new Vector2(x, y);
        }


        // Vector2 worldSapcePoint = LocalToWorld(localSapacePoint);



        DrawBasesVectors(objPos, right, up);
        DrawBasesVectors(Vector2.zero, Vector2.right, Vector2.up);

        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(worldSapcePoint, 0.15f);

        localObjTransform.localPosition = WorldToLocal(worldSapcePoint);
    }




    private void DrawBasesVectors(Vector2 pos, Vector2 right, Vector2 up) {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(pos, right);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(pos, up);

        Gizmos.color = Color.white;
    }

}
