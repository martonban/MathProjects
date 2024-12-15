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

        float distance = (obj_trans - origin).magnitude;

        if (radius <= distance) {
            triggered = false;
            Handles.color = Color.red;
        }else {
            triggered = true;
            Handles.color = Color.green;
        }

        Handles.DrawWireDisc(origin, new Vector3(0,0,1), radius);

    }
    #endif
}
