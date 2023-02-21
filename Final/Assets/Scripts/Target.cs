using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50;
    public GameObject npc;
    public Transform npc2;
    public GameObject npc_ragdoll;
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health == 0) 
        {
            Die();
            health = 50;
        }
    }
    void Die()
    {
        npc.SetActive(false);
        npc_ragdoll.SetActive(true);
        Instantiate(npc_ragdoll, npc2.transform.position, npc2.transform.rotation);
    }
}
