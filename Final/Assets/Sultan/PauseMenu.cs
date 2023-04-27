using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public bool onPause;
    public Camera minimap;
    public Slider mainSlider;

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

    public void MoveCam()
    {

        minimap.orthographicSize = mainSlider.value;
    }
}
