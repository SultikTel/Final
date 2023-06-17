using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void NextLevel() 
    {
        print("next scene");
        SceneManager.LoadScene("CutScene#1");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
