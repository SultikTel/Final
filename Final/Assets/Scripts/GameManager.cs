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
            first_weapon.GetComponent<gun>().message1.SetActive(false);
        }else if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            second_weapon.SetActive(false);
            first_weapon.SetActive(true);
            if(first_weapon.GetComponent<gun>().current_ammo == 0){
                first_weapon.GetComponent<gun>().StartCoroutine(first_weapon.GetComponent<gun>().Reloading());
            }
            //first_weapon.GetComponent<gun>().current_ammo = first_weapon.GetComponent<gun>().max_ammo;
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
