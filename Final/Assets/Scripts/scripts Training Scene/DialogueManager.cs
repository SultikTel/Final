using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clips;
    int currentIndexSound;
    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {
        if(audioSource.isPlaying == false)
        {
            NexSound();
        }
    }
    void NexSound()
    {
        if(currentIndexSound < clips.Length)
        {
            audioSource.clip = clips[currentIndexSound];
            audioSource.Play();
            currentIndexSound++;
        }
    }
}
