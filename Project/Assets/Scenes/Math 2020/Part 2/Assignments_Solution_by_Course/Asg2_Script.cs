using UnityEngine;

public class Asg2_Script : MonoBehaviour {

    [Range(0f, 1f)]
    public float precisness = 05f;

    public Transform objTf;

    private void OnDrawGizmos() {
        Vector2 center = transform.position;
        Vector2 playerPos = objTf.position;
        Vector2 playerLookDir = objTf.right; // x-axis

        Vector2 playerToTriggerDir = (center - playerPos).normalized;

        float lookness = Vector2.Dot(playerLookDir, playerToTriggerDir);

        bool IsLookingTrigger = lookness >= precisness; 


        Gizmos.color = IsLookingTrigger ? Color.green : Color.red;
        Gizmos.DrawLine(playerPos, playerPos + playerToTriggerDir);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(playerPos, playerPos + playerLookDir);
    }
}
