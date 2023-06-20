using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class final_cut_scene : MonoBehaviour
{
    public int duration;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextScene());   
    }
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene("MainMenu");
    }
}
