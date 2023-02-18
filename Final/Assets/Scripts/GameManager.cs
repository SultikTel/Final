using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource source;
    
    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }
}
