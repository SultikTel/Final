using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    public int currentWave = 1;
    public GameObject[][] waveUnits = new GameObject[4][];

    public Text victoryText;

    void Start()
    {
        waveUnits[0] = new GameObject[] { GameObject.Find("Wave1Unit1"), GameObject.Find("Wave1Unit2"), GameObject.Find("Wave1Unit3"), GameObject.Find("Wave1Unit4") };
        waveUnits[1] = new GameObject[] { GameObject.Find("Wave2Unit1"), GameObject.Find("Wave2Unit2"), GameObject.Find("Wave2Unit3"), GameObject.Find("Wave2Unit4") };
        /*waveUnits[2] = new GameObject[] { GameObject.Find("Wave3Unit1"), GameObject.Find("Wave3Unit2"), GameObject.Find("Wave3Unit3"), GameObject.Find("Wave3Unit4") };
        waveUnits[3] = new GameObject[] { GameObject.Find("Wave4Unit1"), GameObject.Find("Wave4Unit2"), GameObject.Find("Wave4Unit3"), GameObject.Find("Wave4Unit4") };*/

        foreach (GameObject unit in waveUnits[0])
        {
            unit.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
