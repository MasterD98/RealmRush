using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns=0.75f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Text score;
    int enemies = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(repeatedlySpawnEnemies(secondsBetweenSpawns));
    }

    IEnumerator repeatedlySpawnEnemies(float secondsBetweenSpawns)
    {
        while (true) {
            EnemyMovement Enemy = Instantiate(enemyPrefab, new Vector3(-10, 15, 0), Quaternion.Euler(0,0,0));
            Enemy.transform.parent = FindObjectOfType<EnemySpawner>().transform;
            score.text = (++enemies).ToString();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
