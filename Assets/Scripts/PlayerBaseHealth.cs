using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBaseHealth : MonoBehaviour
{
    [SerializeField] int baseHealth=100;
    [SerializeField] int damagePerEnemy = 10;
    [SerializeField] Text health;
    [SerializeField] AudioClip enemyReachBaseSFX;
    private void OnTriggerEnter(Collider other)
    {
        baseHealth -= damagePerEnemy;
        health.text = baseHealth.ToString();
        GetComponent<AudioSource>().PlayOneShot(enemyReachBaseSFX);
    }

    void Start()
    {
        health.text = baseHealth.ToString();    
    }
}
