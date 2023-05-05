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
<<<<<<< Updated upstream
        CheckWaveStatus();
    }

    void CheckWaveStatus()
    {
        bool waveComplete = true;
        foreach (GameObject unit in waveUnits[currentWave - 1])
        {
            if (unit.activeSelf)
            {
                waveComplete= false;
                break;
            }
        }

        if(waveComplete)
        {
            currentWave++;
            if(currentWave > 2)
            {
                victoryText.text = "Победа!";
            }
        
        else
        {
                foreach (GameObject unit in waveUnits[currentWave - 1])
                {
                    Debug.Log("Streak");
                    unit.SetActive(true);
                }
            }
        }
=======
        numEnemiesRightNow--;
         if(numEnemiesRightNow == 0)
       {
        second_team.SetActive(true);
       }
>>>>>>> Stashed changes
    }
}
