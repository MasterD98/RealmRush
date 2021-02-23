using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int,Waypoint> grids =new Dictionary<Vector2Int,Waypoint>();
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            if (grids.ContainsKey(waypoint.GetGridPos())) {
                Debug.LogWarning(" skipping overlapping block"+waypoint.name);
            }
            else { grids.Add(waypoint.GetGridPos(), waypoint); }
        }
        print("Loaded "+grids.Count+" blocks");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
