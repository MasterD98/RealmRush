using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    private const int gridsize = 10;
    private Vector2Int GridPos;

    public Vector2 GetGridPos() {
        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridsize) * gridsize,
        Mathf.RoundToInt(transform.position.z / gridsize) * gridsize
        );
    }

    public int GetGridSize() { return gridsize; }
}
