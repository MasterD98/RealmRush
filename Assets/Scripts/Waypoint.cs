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
    public bool isPlaceble = true;
    [SerializeField] Tower towerPrefab;

    private void Start()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (isPlaceble)
            {
                Instantiate(towerPrefab,new Vector3(transform.position.x,10f,transform.position.z),Quaternion.identity);
                isPlaceble = false;
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
