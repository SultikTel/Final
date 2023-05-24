using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health = 50;
    public GameObject NPC_Ragdoll;
    public GameObject wavecontroller;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health == 0)
        {
            //health = 50;
            Die();
        }
    }
    public void Die()
    {
        if(wavecontroller.GetComponent<WaveController>()!= false)
        {
            wavecontroller.GetComponent<WaveController>().EnemyDead();
        }
        gameObject.SetActive(false);
        NPC_Ragdoll.SetActive(true);
        Instantiate(NPC_Ragdoll, transform.position, transform.rotation);
    }
}
