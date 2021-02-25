using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;
    // Start is called before the first frame update
    private void Awake()
    {
        waypoint=GetComponent<Waypoint>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateName();

    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(
            waypoint.GetGridPos().x*gridSize,
            0f,
            waypoint.GetGridPos().y*gridSize
        );
    }

    private void UpdateName()
    {
        string blockLabel = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        gameObject.name = blockLabel;
    }
}
