using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class enemy_death : MonoBehaviour
{
    public int health = 50;
    public GameObject NPC_Ragdoll;
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
            health = 50;
            Die();
        }
    }
    void Die()
    {
        win_text.SetActive(true);
        //button.SetActive(true);
        gameObject.SetActive(false);
        NPC_Ragdoll.SetActive(true);
        Instantiate(NPC_Ragdoll, transform.position, transform.rotation);
        SceneManager.LoadScene("TrainingLevel");
    }
}
