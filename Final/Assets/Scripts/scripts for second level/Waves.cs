using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public GameObject[] teams_enemy;
    int index;
    int numsEnemiesRightNow;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        teams_enemy[1].SetActive(false);
        numsEnemiesRightNow = teams_enemy[index].transform.childCount;
    }

    public void Enemy_death()
    {
        numsEnemiesRightNow--;
        if(numsEnemiesRightNow == 0)
        {
            if(index < teams_enemy.Length - 1){
               index++;
               teams_enemy[index].SetActive(true);
               print("First wave is passed");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
