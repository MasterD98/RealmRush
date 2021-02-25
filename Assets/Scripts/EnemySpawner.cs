using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns=2f;
    [SerializeField] EnemyMovement enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(repeatedlySpawnEnemies(secondsBetweenSpawns));
    }

    IEnumerator repeatedlySpawnEnemies(float secondsBetweenSpawns)
    {
        while (true) {
            Instantiate(enemyPrefab, new Vector3(-10, 10, 0), Quaternion.Euler(0,90,0));
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
