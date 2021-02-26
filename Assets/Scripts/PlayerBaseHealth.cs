using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        if (baseHealth == 0) { 
            //TODO manage Scenes
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        GetComponent<AudioSource>().PlayOneShot(enemyReachBaseSFX);
    }

    void Start()
    {
        health.text = baseHealth.ToString();    
    }
}
