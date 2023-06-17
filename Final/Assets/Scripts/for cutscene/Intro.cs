using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Intro : MonoBehaviour
{
    public int duringTime;
    public AudioSource source;
    public AudioClip[] sounds;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(OpenScene());
    }
    void Update()
    {
        Skip(); 
        
        if(source.isPlaying)
        {
            //print("Yes, he is still playing");
        }else NextSound();
    }
    IEnumerator OpenScene()
    {
        yield return new WaitForSeconds(duringTime);
        SceneManager.LoadScene(2);
    }
    void Skip()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(2);
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
