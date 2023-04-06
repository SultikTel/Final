using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBySultan : MonoBehaviour
{
    [SerializeField]
    public bool isFirstwave;

    public GameObject German_Ragdoll;
    public int health = 50;

    public LevelGoing lvl;

    void Start()
    {
        lvl=Object.FindObjectOfType<LevelGoing>();


    }

    public void getAlive()
    {
        gameObject.SetActive(true);
    }

    public void getFade()
    {
        gameObject.SetActive(false);
    }

    public void die()
    {
        getFade();
        lvl.EnemyDown();

        this.gameObject.SetActive(false);
        German_Ragdoll.SetActive(true);
        Instantiate(German_Ragdoll, transform.position, transform.rotation);

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health == 0)
        {
            die();
        }
    }


}
