using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LevelGoing : MonoBehaviour
{
    public ArrayList enemy;
    public ArrayList enemiesRightNow;
    public int numEnemiesRightNow;
    public int waveRightNow;
    public TMP_Text text;
    public Text tasks;
    public Text enemiesLeft;

    public FPS_first_level fps;



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
        tasks.text = "Очистить станцию";
        enemiesLeft.text= "Осталось врагов:" + numEnemiesRightNow.ToString();
        
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

                Save();
            }
            else
            {
                SecondWavePassed();
            }
        }

        enemiesLeft.text = "Осталось врагов:" + numEnemiesRightNow.ToString();

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

        ShowText("Need to clear the village");
        waveRightNow = 2;

        tasks.text = "Очистить деревню";

    }

    public void SecondWavePassed()
    {
        ShowText("YouWon");
        tasks.text = "Заданий нет";
        enemiesLeft.text = "";
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




    public void Save()
    {
        SerializationManager.Save(this, fps);
    }

    public void Load()
    {
        LevelState data =  SerializationManager.Load();
        fps.currentHealth = data.playerHealth;
        Vector3 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];
        position.z = data.playerPosition[2];
        fps.transform.position = position;

        if (waveRightNow == 1)
        {
            enemy = new ArrayList(FindObjectsOfType<EnemyBySultan>());

            foreach (EnemyBySultan i in enemy)
            {
                if (i.isFirstwave == true)
                {
                    i.getFade();
                }

            }

            FirstWavePassed();
        }
    }
}
