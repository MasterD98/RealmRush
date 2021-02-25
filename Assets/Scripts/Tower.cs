using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform TargetEnemy;
    [SerializeField] float attackRange=30f;
    // Update is called once per frame
    void Update()
    {
        if (TargetEnemy )
        {
            objectToPan.LookAt(TargetEnemy);
            FireAtEnemy();
            
        }
        else { Shoot(false); }
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
