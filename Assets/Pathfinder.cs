using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWaypoint;
    Dictionary<Vector2Int,Waypoint> grids =new Dictionary<Vector2Int,Waypoint>();
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        SetStartEndWaypontColors();
    }

    private void SetStartEndWaypontColors()
    {
        startWaypoint.SetWayPointColor(Color.green);
        endWaypoint.SetWayPointColor(Color.red);
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
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
