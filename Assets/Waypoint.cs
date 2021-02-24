using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint exploredFrom;
    [SerializeField] Color exploredColor=Color.blue;
    private const int gridsize = 10;
    private Vector2Int gridPos;
    public bool isExplored = false;

    private void Start()
    {
        
    }
    public Vector2Int GetGridPos() {
        gridPos=new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridsize),
        Mathf.RoundToInt(transform.position.z / gridsize)
        );
        return gridPos;
    }
    public void SetWayPointColor(Color color) {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

    private void Update()
    {
        SetExploredWaypointColor();
    }

    private void SetExploredWaypointColor()
    {
        if (isExplored)
        {
            SetWayPointColor(exploredColor);
        }
    }

    public int GetGridSize() { return gridsize; }
}
