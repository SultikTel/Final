using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGoing : MonoBehaviour
{
    public ArrayList enemy;
    public ArrayList enemiesRightNow;
    public int numEnemiesRightNow;
    public int waveRightNow;
    public Text text;
    public Text tasks;



    // Start is called before the first frame update
    void Start()
    {

        waveRightNow = 1;
        enemy = new ArrayList(FindObjectsOfType<EnemyBySultan>());

        foreach (EnemyBySultan i in enemy)
        {
            if (i.isFirstwave == false)
            {
                i.getFade();
            }
        }


        enemiesRightNow = new ArrayList(FindObjectsOfType<EnemyBySultan>());
        numEnemiesRightNow = enemiesRightNow.Count;
        tasks.text = "Очистить станцию" +
           "\n"+ "Осталось врагов:" + numEnemiesRightNow.ToString();
    }

    // Update is called once per frame
    public void EnemyDown()
    {
        numEnemiesRightNow--;
        if (numEnemiesRightNow == 0)
        {
            if (waveRightNow == 1)
            {
                FirstWavePassed();
            }
            else
            {
                SecondWavePassed();
            }
        }

    }

    public void FirstWavePassed()
    {

        foreach (EnemyBySultan i in enemy)
        {
            if (i.isFirstwave == false)
            {
                i.getAlive();
            }
        }

        enemiesRightNow = new ArrayList(FindObjectsOfType<EnemyBySultan>());
        numEnemiesRightNow = enemiesRightNow.Count;

        ShowText("NeedToDef second wave");
        waveRightNow = 2;
    }

    public void SecondWavePassed()
    {
        ShowText("YouWon");
        
    }


    public void ShowText(string word)
    {
        text.text = word;
        StartCoroutine(Show());
    }


    IEnumerator Show()
    {
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        text.gameObject.SetActive(false);
    }
}
