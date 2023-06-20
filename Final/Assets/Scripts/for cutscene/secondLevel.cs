using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class secondLevel : MonoBehaviour
{
    public int duringTime;
    public AudioSource source;
    public AudioClip[] sounds;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OpenScene());
    }
    void Update()
    {
        Skip(); 

        if(source.isPlaying == false)
        {
            NextSound();
        }
    }
    IEnumerator OpenScene()
    {
        yield return new WaitForSeconds(duringTime);
         SceneManager.LoadScene(6);
    }
    void Skip()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(6);
        }
    }
    void NextSound()
    {
        if(index < sounds.Length)
        {
            source.clip = sounds[index];
            source.Play();
            index++;
        }
    }
}
