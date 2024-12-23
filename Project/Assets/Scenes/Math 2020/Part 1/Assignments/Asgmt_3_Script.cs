using System.Net;
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

    public Transform copyPoint; 

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
        DrawMyGizmos();

        TransformCopyPoint(point_pos);

    }


    private void TransformCopyPoint(Vector2 point_pos) {
        Vector2 final_positon = new Vector2(0f, 0f);
        if (convertToLocalSpace) {
            final_positon = WorldToLocal(point_pos);
        }

        if (convertToWorldSpace) {
            final_positon = LocalToWorld(point_pos);
        }

        copyPoint.transform.position = final_positon;
    }

    private Vector2 WorldToLocal(Vector2 current_pos) {
        float dotX = Vector2.Dot(worldX, current_pos);
        float dotY = Vector2.Dot(worldY, current_pos);
        
        Vector2 deltaX = localX - localOrigin;
        Vector2 deltaY = localY - localOrigin;
        Vector2 result = localOrigin + (deltaX * dotX + deltaY * dotY);
        return result;
    }

    private Vector2 LocalToWorld(Vector2 current_pos) {
        float dotX = Vector2.Dot(localX, current_pos);
        float dotY = Vector2.Dot(localX, current_pos);

        Vector2 deltaX = worldX - worldOrigin;
        Vector2 deltaY = worldY - worldOrigin;
        Vector2 result = worldOrigin + (deltaX * dotX + deltaY * dotY);
        return result;
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