using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    bool isRunning = true;
    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWaypoint;
    Dictionary<Vector2Int,Waypoint> grids =new Dictionary<Vector2Int,Waypoint>();
    Vector2Int[] directions =  {Vector2Int.up,Vector2Int.right,Vector2Int.down,Vector2Int.left};
    Queue<Waypoint> queue = new Queue<Waypoint>();
    Waypoint searchCenter;
    private List<Waypoint> path = new List<Waypoint>();
    private void CreatePath()
    {
        Waypoint previous=endWaypoint;
        while (previous != null) {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Reverse();
    }

    private void BreathFirstSearch()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning) {
            searchCenter=queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }
        //todo work out
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions) {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            if (grids.ContainsKey(neighbourCoordinates)) { QueueNewNeighbour(neighbourCoordinates); }
        }
    }

    private void QueueNewNeighbour(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grids[neighbourCoordinates];
        if (!(neighbour.isExplored ||queue.Contains(neighbour)))
        {
            neighbour.exploredFrom = searchCenter;
            queue.Enqueue(neighbour);
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
            }else
            { 
                grids.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }

    public List<Waypoint> GetPath()
    {
        if (path.Count==0)
        {
            CaclulatePath();
        }
        return path;
    }

    private void CaclulatePath()
    {
        LoadBlocks();
        SetStartEndWaypontColors();
        BreathFirstSearch();
        CreatePath();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
