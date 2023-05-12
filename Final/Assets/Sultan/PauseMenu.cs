using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public bool onPause;
    public Camera minimap;
    
    public AudioSource backGroundMusic;

    // Update is called once per frame

    private void Start()
    {
        onPause = false;
        PausePanel.SetActive(false);
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (onPause)
            {
                Resume();
                
            }
            else
            {
                Pause();
                
            }
        }
        
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        onPause = true;

    }
    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        onPause = false;

    }

    public void MoveCam(float value)
    {

        minimap.orthographicSize = (value * 100+20f);
    }

    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetVolume(float value)
    {
        backGroundMusic.volume = value;
    }
}
