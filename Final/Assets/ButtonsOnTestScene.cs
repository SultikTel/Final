using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsOnTestScene : MonoBehaviour
{
    public void LoadFirstSave()
    {

        if (PlayerPrefs.GetFloat("SceneOfFirstSave") == 1)
        {
            PlayerPrefs.SetInt("LoadedBySave1", 1);
            SceneManager.LoadScene(2);
            
        }
        else
        {
            PlayerPrefs.SetInt("LoadedBySave1", 1);
            SceneManager.LoadScene(3);
            
        }
    }


    public void LoadSecondSave()
    {

        

    }

    public void LoadThirdSave()
    {

    }
}
