using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int HitPoints=10;

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (HitPoints <= 1) { KillEnemy(); }
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        HitPoints--;
    }

    // Update is called once per frame
    void Update()
    {   
    }
}
