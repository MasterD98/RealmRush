using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int HitPoints=10;
    [SerializeField] ParticleSystem hitParticlesPrefab;
    [SerializeField] ParticleSystem deathParticlesPrefab;

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (HitPoints <= 1) { KillEnemy(); }
    }

    private void KillEnemy()
    {
        ParticleSystem vfx = Instantiate(deathParticlesPrefab,transform.position,Quaternion.identity);
        vfx.Play();
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        HitPoints--;
        hitParticlesPrefab.Play();
    }

    // Update is called once per frame
    void Update()
    {   
    }
}
