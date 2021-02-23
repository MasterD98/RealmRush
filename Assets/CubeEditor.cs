﻿using System.Collections;
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
        UpdateLabel();

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

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string blockLabel = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        textMesh.text = blockLabel;
        gameObject.name = blockLabel;
    }
}
