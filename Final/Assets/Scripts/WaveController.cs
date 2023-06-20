using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    public GameObject[] teams;
    int index;
    int numEnemiesRightNow;
    public Text WaveText;
    public GameObject WaveTextGameObject;
    public GameObject button;
    void Start()
    {
        index = 0;
        teams[1].SetActive(false);
        teams[2].SetActive(false);
        numEnemiesRightNow = teams[index].transform.childCount;
        WaveTextGameObject.SetActive(false);
        button.SetActive(false);
    }

    public void EnemyDead()
    {
      numEnemiesRightNow--;
      if(numEnemiesRightNow == 0){
        if(index < teams.Length - 1)
        {
            index++;
            teams[index].SetActive(true); 
            WaveText.text = "Wave" + index + " is passed";  
            StartCoroutine(ShowText());
            numEnemiesRightNow = teams[index].transform.childCount;
        }else {
            WaveText.text = "All wave is passed";
            StartCoroutine(ShowText());
            button.SetActive(true);
            //Time.timeScale = 0f;
        }
      }
    }
    IEnumerator ShowText()
    {
        WaveTextGameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        WaveTextGameObject.SetActive(false);
    }
}
