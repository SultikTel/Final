using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    int health = 10;
    public GameObject enemy_ragdoll;

    
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    // Update is called once per frame
    void Update()
    {
         if(health == 0)
        {
            Die();
        }
    }
    public void Die()
    {
        GameObject findWaves = GameObject.Find("WaveController");
        Waves wave_controller = findWaves.GetComponent<Waves>();
        //wave_controller.Enemy_death();
        if(wave_controller!=null){
           wave_controller.Enemy_death();
        }
        gameObject.SetActive(false);
        enemy_ragdoll.SetActive(true);
        Instantiate(enemy_ragdoll, transform.position, transform.rotation);
    }
}
