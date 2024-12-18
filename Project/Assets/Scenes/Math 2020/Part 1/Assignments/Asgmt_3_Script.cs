using UnityEditor;
using UnityEngine;

/*
 *-------------------------------------------------------------------------------------
 *  In this Assignment I have to create two funcions. One converts a point from world
 *  space to local space, while the other converts from local space to world space.
 *  Note I CAN'T USE MATRIXES JUST SIMPLE VECTOR OPERATIONS AND DOT PRODUCTS.
 *-------------------------------------------------------------------------------------
 */

public class Asgmt_3_Script : MonoBehaviour {
    // Point realted variabels
    public bool convertToLocalSpace = false;
    public bool convertToWorldSpace = false;
    Vector2 point_pos;

    // World Space's Transform
    public Transform worldSpaceOrigin; 
    public Transform worldSpaceX; 
    public Transform worldSpaceY;

    public Vector2 worldOrigin;
    public Vector2 worldY;
    public Vector2 worldX;


    // Local Space's Transform
    public Transform localSpaceOrigin;
    public Transform localSpaceX;
    public Transform localSpaceY;

    public Vector2 localOrigin;
    public Vector2 localY;
    public Vector2 localX;



    private void OnDrawGizmos() {
        point_pos = this.transform.position;

        // Draw helper lines
        // World X axis
        DrawMyGizmos();


        if (convertToLocalSpace) {
            this.transform.position = WorldToLocal(point_pos);
        } else {
            this.transform.position = LocalToWorld(point_pos);
        }
    }


    private Vector2 WorldToLocal(Vector2 current_pos) {
        return new Vector2(10f, 10f);
    }


    private Vector2 LocalToWorld(Vector2 current_pos) {
        return new Vector2(0f, 0f);
    }

    private void DrawMyGizmos() {
        Gizmos.color = Color.red;
        worldOrigin = worldSpaceOrigin.position;
        worldX = worldSpaceX.position;
        Gizmos.DrawLine(worldOrigin, worldX);

        localOrigin = localSpaceOrigin.position;
        localX = localSpaceX.position;
        Gizmos.DrawLine(localOrigin, localX);

        Gizmos.color = Color.green;
        worldY = worldSpaceY.position;
        Gizmos.DrawLine(worldOrigin, worldY);

        localY = localSpaceY.position;
        Gizmos.DrawLine(localOrigin, localY);
    }


}