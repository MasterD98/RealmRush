using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{   //parameters
    [SerializeField] Transform objectToPan;
    
    [SerializeField] float attackRange=30f;
    //state 
    Transform TargetEnemy;
    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (TargetEnemy)
        {
            objectToPan.LookAt(TargetEnemy);
            FireAtEnemy();
            
        }
        else { Shoot(false); }
    }

    private void SetTargetEnemy()
    {
        EnemyDamage[] Enemies = FindObjectsOfType<EnemyDamage>();
        if (Enemies.Length==0) { return; }
        Transform closestEnemy = Enemies[0].transform;
        foreach (EnemyDamage testEnemy in Enemies) {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        TargetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform closestEnemy, Transform testEnemy)
    {
        float disToTestEnemy = Vector3.Distance(gameObject.transform.position, testEnemy.gameObject.transform.position);
        float disToClosestEnemy = Vector3.Distance(gameObject.transform.position, closestEnemy.transform.position);
        if (disToTestEnemy<disToClosestEnemy )
        {
            return testEnemy;
        }
        return closestEnemy;
    }

    private void FireAtEnemy()
    {
        if (Vector3.Distance(gameObject.transform.position, TargetEnemy.position) <= attackRange) { Shoot(true);}
    }

    private void Shoot(bool isActive)
    {
        ParticleSystem.EmissionModule emission = GetComponentInChildren<ParticleSystem>().emission;
        emission.enabled=isActive;
    }
}
