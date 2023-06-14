using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip weapon_switch;
    public GameObject first_weapon; //don't touch
    public GameObject second_weapon; //don't touch

    void Start() 
    {
        second_weapon.SetActive(false); //code by ramazan
        second_weapon.GetComponent<Bazooka2>().Deactivation();
    }
    
    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound); //play sound 
    }

    public void NexLevel()
    {
        SceneManager.LoadScene(3); //button to open first mission
    }

    public void SecondMission()
    {
        SceneManager.LoadScene(6); //button to open second mission
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
            second_weapon.GetComponent<Bazooka2>().ActiveReloadText();
            first_weapon.GetComponent<gun>().message1.SetActive(false);
            first_weapon.GetComponent<gun>().ammo_text.enabled = false;
            source.PlayOneShot(weapon_switch);
        }else if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            second_weapon.SetActive(false);
            first_weapon.SetActive(true);
            source.PlayOneShot(weapon_switch);
            second_weapon.GetComponent<Bazooka2>().Deactivation();
            first_weapon.GetComponent<gun>().ammo_text.enabled = true;
            if(first_weapon.GetComponent<gun>().current_ammo == 0){
                first_weapon.GetComponent<gun>().StartCoroutine(first_weapon.GetComponent<gun>().Reloading());
            }
        }
    }
}
