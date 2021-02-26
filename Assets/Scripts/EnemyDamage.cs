using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int HitPoints=10;
    [SerializeField] ParticleSystem hitParticlesPrefab;
    [SerializeField] ParticleSystem deathParticlesPrefab;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;

    private void Start()
    {
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (HitPoints <= 0) { KillEnemy(); }
    }

    private void KillEnemy()
    {
        ParticleSystem vfx = Instantiate(deathParticlesPrefab,transform.position,Quaternion.identity);
        vfx.Play();
        GetComponent<AudioSource>().PlayOneShot(enemyDeathSFX);
        AudioSource.PlayClipAtPoint(enemyDeathSFX, FindObjectOfType<Camera>().transform.position);
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        HitPoints--;
        hitParticlesPrefab.Play();
        GetComponent<AudioSource>().PlayOneShot(enemyHitSFX);
    }

    public void SelfDestruct() {
        ParticleSystem vfx = Instantiate(deathParticlesPrefab, transform.position, Quaternion.identity);
        vfx.Play();
        
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {   
    }
}
