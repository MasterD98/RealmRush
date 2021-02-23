using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(PrinAllWayPoints());
    }

    IEnumerator PrinAllWayPoints()
    {
        print("Starting patrol");
        foreach (Waypoint waypoint in path)
        {
            print("Visiting block :" + waypoint.gameObject.name);
            transform.position = new Vector3(waypoint.transform.position.x,5f,waypoint.transform.position.z);
            yield return new WaitForSeconds(1f);
        }
        print("ending patrol..");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
