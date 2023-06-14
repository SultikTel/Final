using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class firstlevel_cutscene : MonoBehaviour
{
    public int duringTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OpenScene());
    }
    void Update()
    {
        Skip(); 
    }
    IEnumerator OpenScene()
    {
        yield return new WaitForSeconds(duringTime);
        SceneManager.LoadScene(4);
    }
    void Skip()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(4);
        }
    }
}
