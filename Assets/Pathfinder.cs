using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWaypoint;
    Dictionary<Vector2Int,Waypoint> grids =new Dictionary<Vector2Int,Waypoint>();
    Vector2Int[] directions =  {Vector2Int.up,Vector2Int.right,Vector2Int.down,Vector2Int.left};
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        SetStartEndWaypontColors();
        Exploreneighbours();
    }

    private void Exploreneighbours()
    {
        foreach (Vector2Int direction in directions) {
            Vector2Int explorationCoordinates = startWaypoint.GetGridPos() + direction;
            try { grids[explorationCoordinates].SetWayPointColor(Color.blue);
            }
            catch (Exception ex) {
                Debug.LogWarning(ex.Message);
            }
            
        }
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
