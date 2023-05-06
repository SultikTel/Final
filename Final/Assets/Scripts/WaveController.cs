using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    public GameObject first_team;
    public GameObject second_team;
    public int numEnemiesRightNow;

    void Start()
    {
        second_team.SetActive(false);
        numEnemiesRightNow = first_team.transform.childCount;
    }

    
    public void EnemyDead()
    {
        numEnemiesRightNow--;
         if(numEnemiesRightNow == 0)
       {
        second_team.SetActive(true);
       }
    }
}
