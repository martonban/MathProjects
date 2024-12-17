using System.Net;
using UnityEngine;

/*
 *-------------------------------------------------------------------------------------
 *  In this Assignment I have to create a look at trigger. This trgger will be have a 
 *  threshold between 0 - 1. If this value is 1 it means player looking it directly,
 *  if it is 0 for example perpendicularor totaly looking away.
 *-------------------------------------------------------------------------------------
 */



public class Asgmt_2_Script : MonoBehaviour {

    public Transform view_ray_obj;
    public Transform point_obj;
    public bool look_at_trigger;
    public float dot_product;
    
    [Range(0f, 1f)]
    public float lookAtThreshold = 0f;

    private void OnDrawGizmos() {

        // Basic Vectors
        Vector2 player_pos = this.transform.position;
        Vector2 view_ray = view_ray_obj.transform.position;
        Vector2 point_pos = point_obj.transform.position;

        // Normal Vector Calculations
        Vector2 player_view_normalized = (view_ray - player_pos).normalized;
        Vector2 player_object_normalized = (point_pos - player_pos).normalized;

        // Debug lines draw
        // We have to transfom a lot in this case
        Gizmos.DrawLine(player_pos, player_view_normalized + player_pos);
        Gizmos.DrawLine(player_pos, player_object_normalized+ player_pos);

        // Look at trigger
        dot_product = Vector2.Dot(player_object_normalized, player_view_normalized);

        if (dot_product >= lookAtThreshold) {
            look_at_trigger = true;
        } else { 
            look_at_trigger= false;
        }
    
    }
}
