using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class firstlevel_cutscene : MonoBehaviour
{
    public int duringTime;
    public AudioSource source;
    public AudioClip[] sounds;
    int currentSound;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OpenScene());
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        Skip(); 
        if(source.isPlaying)
        {
            //print is playing
        }else NextSound();
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
    void NextSound()
    {
        if(currentSound < sounds.Length)
        {
            source.clip = sounds[currentSound];
            source.Play();
            currentSound++;
        }   
    }
}
