using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager2 : MonoBehaviour
{
    public AudioSource source;
    public AudioClip weapon_switch;
    public GameObject first_weapon; 
    public GameObject second_weapon;
    public GameObject bazooka_btn;
    public GameObject kalashnik_btn;
    public GameObject bazooka_standard_buttons;
    public GameObject kalashnik_standard_buttons;
    private bool switches;
    void Start() 
    {
        second_weapon.SetActive(false);
        second_weapon.GetComponent<Bazooka_mobile>().Deactivation();
        kalashnik_btn.SetActive(false);
        bazooka_standard_buttons.SetActive(false);
    }
    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound); //play sound 
    }
    public void SecondMission()
    {
        SceneManager.LoadScene(5); //button to open second mission
    }
    void Update()
    {
 
    }
    public void Bazooka()
    {
        second_weapon.SetActive(true);
        first_weapon.SetActive(false);
        second_weapon.GetComponent<Bazooka_mobile>().ActiveReloadText();
        first_weapon.GetComponent<Fire_mobile>().message1.SetActive(false);
        first_weapon.GetComponent<Fire_mobile>().ammo_text.enabled = false;
        source.PlayOneShot(weapon_switch);
        bazooka_btn.SetActive(false);
        kalashnik_btn.SetActive(true);
        kalashnik_standard_buttons.SetActive(false);
        bazooka_standard_buttons.SetActive(true);
    }
    public void Kalashnik()
    {
        second_weapon.SetActive(false);
        first_weapon.SetActive(true);
        source.PlayOneShot(weapon_switch);
        second_weapon.GetComponent<Bazooka_mobile>().Deactivation();
        first_weapon.GetComponent<Fire_mobile>().ammo_text.enabled = true;
        if(first_weapon.GetComponent<Fire_mobile>().current_ammo == 0){
            first_weapon.GetComponent<Fire_mobile>().StartCoroutine(first_weapon.GetComponent<Fire_mobile>().Reloading());
        }
        bazooka_btn.SetActive(true);
        kalashnik_btn.SetActive(false);
        kalashnik_standard_buttons.SetActive(true);
        bazooka_standard_buttons.SetActive(false);
    }
}
