using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GermanSoldier : MonoBehaviour
{
    public GameObject German_Ragdoll;
    public int health = 50;
    public GameObject win_text;
    public GameObject button;
    void Start()
    {
        win_text.SetActive(false);
        button.SetActive(false);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health == 0)
        {
            Die();
        }
    }
    public void Die()
    {
        this.gameObject.SetActive(false);
        German_Ragdoll.SetActive(true);
        Instantiate(German_Ragdoll, transform.position, transform.rotation);
        win_text.SetActive(true);
        button.SetActive(true);
    }
}
