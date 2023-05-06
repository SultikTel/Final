using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource source;
    public GameObject first_weapon;
    public GameObject second_weapon;
    void Start() 
    {
        second_weapon.SetActive(false);
    }
    void Update()
    {
        ChangeWeapon();
    }
    void ChangeWeapon()
    {
        if(Input.GetKeyDown(KeyCode.Keypad2))
        {
            second_weapon.SetActive(true);
            first_weapon.SetActive(false);
        }else if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            second_weapon.SetActive(false);
            first_weapon.SetActive(true);
        }
    }

    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }
    public void NexLevel()
    {
        SceneManager.LoadScene(2);
    }
}
