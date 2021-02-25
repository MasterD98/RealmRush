using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint exploredFrom;
    private const int gridsize = 10;
    private Vector2Int gridPos;
    public bool isExplored = false;
    public bool isPlaceble = true;
    

    private void Start()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (isPlaceble)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }else {
                print("can't place hear");
            }
        }
        
    }
    public Vector2Int GetGridPos() {
        gridPos=new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridsize),
        Mathf.RoundToInt(transform.position.z / gridsize)
        );
        return gridPos;
    }

    private void Update()
    {
        
    }
    public int GetGridSize() { return gridsize; }
}
