using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource source;
    public GameObject first_weapon; //don't touch
    public GameObject second_weapon; //don't touch
    


    void Start() 
    {
        second_weapon.SetActive(false); //code by ramazan
    }
    
    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound); //play sound 
    }

    public void NexLevel()
    {
        SceneManager.LoadScene(2); //button to open next level
    }

    void Update()
    {
        ChangeWeapon();   //code by Ramazan dont'touch
    }

    //Here edited by Ramazan, don't touch!
    void ChangeWeapon()
    {
        if(Input.GetKeyDown(KeyCode.Keypad2))
        {
            second_weapon.SetActive(true);
            first_weapon.SetActive(false);
            first_weapon.GetComponent<gun>().message1.SetActive(false);
        }else if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            second_weapon.SetActive(false);
            first_weapon.SetActive(true);
            if(first_weapon.GetComponent<gun>().current_ammo == 0){
                first_weapon.GetComponent<gun>().StartCoroutine(first_weapon.GetComponent<gun>().Reloading());
            }
        }
    }
}
