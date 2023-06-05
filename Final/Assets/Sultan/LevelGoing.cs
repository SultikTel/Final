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

    public Checkpoint_1 checkpoint;

    public FPS_first_level fps;

    public GameObject fps_transform;

    public HealthBar health;



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


        checkpoint = GetComponent<Checkpoint_1>();

        if (PlayerPrefs.GetInt("LoadedBySave1") == 1)
        {

            fps.currentHealth = PlayerPrefs.GetFloat("Hp_onfirstSave");
            fps_transform.transform.position = new Vector3(PlayerPrefs.GetFloat("X_onfirstSave"), PlayerPrefs.GetFloat("Y_onfirstSave"), PlayerPrefs.GetFloat("Z_onfirstSave"));
            Debug.Log(PlayerPrefs.GetFloat("Hp_onfirstSave"));
            fps.TakeDamage();
            PlayerPrefs.SetInt("LoadedBySave1", 0);
        }
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

                checkpoint.Save(PlayerPrefs.GetFloat("Hp_onfirstSave"), fps_transform.transform, 2);
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

        Debug.Log("Norm");
        checkpoint.Save(fps.currentHealth,fps_transform.transform,2);

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

}
