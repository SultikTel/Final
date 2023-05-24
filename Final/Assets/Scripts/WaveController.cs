using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    public GameObject first_team;
    public GameObject second_team;
    public GameObject third_team;
    public int numEnemiesRightNow;
    public Text WaveText;
    public GameObject WaveTextGameObject;
    void Start()
    {
        third_team.SetActive(false);
        second_team.SetActive(false);
        numEnemiesRightNow = first_team.transform.childCount;
        WaveTextGameObject.SetActive(false);
    }

    
    public void EnemyDead()
    {
        numEnemiesRightNow--;
         if(numEnemiesRightNow == 0)
        {
            second_team.SetActive(true); 
            WaveText.text = "First wave is passed";  
            StartCoroutine(ShowText());
            if(second_team.transform.childCount == 0)
            {
               third_team.SetActive(true);
               WaveText.text = "Second wave is passed";
            }
        }
    }
    IEnumerator ShowText()
    {
        WaveTextGameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        WaveTextGameObject.SetActive(false);
    }
    /*void ChangeTextValue()
    {
        if(Second_Otryad())
        {
            WaveText.text = "First wave is passed.";
        }
    }
    bool Second_Otryad()
    {
        second_team.SetActive(true);
        return true;
    }*/
}
