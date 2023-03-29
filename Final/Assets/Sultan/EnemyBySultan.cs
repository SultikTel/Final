using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBySultan : MonoBehaviour
{
    [SerializeField]
    public bool isFirstwave;

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
        
    }


}
