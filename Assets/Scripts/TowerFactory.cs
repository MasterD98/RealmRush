using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5;

    Queue<Tower> towers = new Queue<Tower>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddTower(Waypoint baseWaypoint) {
        int numOfTowers = towers.Count;
        if (numOfTowers < towerLimit)
        {
            InstatiateNewTower(baseWaypoint);
        }
        else { MoveExistingTower(baseWaypoint); }
    }

    private void MoveExistingTower(Waypoint baseWaypoint)
    {
        Tower oldTower = towers.Dequeue();
        oldTower.baseWaypoint.isPlaceble = true;
        oldTower.baseWaypoint = baseWaypoint;
        oldTower.transform.position =new Vector3(baseWaypoint.transform.position.x,10f,baseWaypoint.transform.position.z);
        baseWaypoint.isPlaceble = false;
        towers.Enqueue(oldTower);
    }

    private void InstatiateNewTower(Waypoint baseWaypoint)
    {
        Tower newTower = Instantiate(towerPrefab, new Vector3(baseWaypoint.transform.position.x, 10f, baseWaypoint.transform.position.z), Quaternion.identity);
        newTower.transform.parent=FindObjectOfType<TowerFactory>().transform;
        newTower.baseWaypoint=baseWaypoint;
        baseWaypoint.isPlaceble = false;
        towers.Enqueue(newTower);
    }
}
