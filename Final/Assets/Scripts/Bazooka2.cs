﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bazooka2 : MonoBehaviour
{
    public Camera MainCamera;
    public int current_ammo;
    public int magazine = 3;
    public int count;
    public GameManager gamemanager;
    public AudioClip shoot;
    public GameObject reload_text;
    public ParticleSystem fire;
    public ParticleSystem Vzriv;
    public GameObject vzriv_gameobject;
    public GameObject bullet_impact;
    private GameObject panzer;
    public GameObject panzer_destroyed;
    public bool exploded;
    public GameObject bullet_prefab;

    //WaveController to count enemy otryad
    public GameObject wavecontroller;
    // Start is called before the first frame update
    void Start()
    {
        fire.Stop(); //particles
        Vzriv.Stop(); //particles
        current_ammo = magazine; 
        exploded = false;

        reload_text.GetComponent<Text>().text = "Bazooka Ammo: " + current_ammo.ToString(); //Here i count how many bullets 
        //i have left showing in the text 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && current_ammo > 0)
        {
            Shoot(); //Call method shoot
            fire.Play(); //play particles
            gamemanager.PlaySound(shoot); //play sound shoot
            current_ammo -= 1;
            reload_text.GetComponent<Text>().text = "Bazooka Ammo: " + current_ammo.ToString();
        }
        if (count == 3 && !exploded && panzer != null) //Check if our count bullets = 3 and he triggered by tank then play effects vzriv
        {
            wavecontroller.GetComponent<WaveController>().EnemyDead();
            exploded = false;
            count = 0;
            StartCoroutine(Panzer_death());
        }
    }

    IEnumerator Panzer_death()
    {
        Instantiate(Vzriv, panzer.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(.7f);
        panzer.SetActive(false);
        panzer_destroyed.SetActive(true);
        Instantiate(panzer_destroyed, panzer.transform.position, panzer.transform.rotation);
    }

    void Shoot()
    {
        if (Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out RaycastHit Hitinfo, 100))
        {
            //Debug.Log(Hitinfo.transform.name);
            if (Hitinfo.transform.CompareTag("Panzer")) //to destroy tanks
            {
                count += 1;
                panzer = Hitinfo.transform.gameObject;
            }
            if(Hitinfo.transform.CompareTag("germans")) //to destroy germans soldier
            {
                print("germans");
                Target health_bar_enemy = Hitinfo.transform.GetComponent<Target>();
                health_bar_enemy.Die();
            }
            if (Hitinfo.rigidbody != null) // to make objects move from bullets
            {
                Hitinfo.rigidbody.AddForce(-Hitinfo.normal * 80);
            }

            GameObject impact_clone = Instantiate(bullet_impact, Hitinfo.point, Quaternion.LookRotation(Hitinfo.normal)); //to put effects billet impact
            Destroy(impact_clone, 1.5f);

            GameObject boom = Instantiate(vzriv_gameobject, Hitinfo.point, Quaternion.LookRotation(Hitinfo.normal)); //to put effect vzriv
            Destroy(boom, 2f);
        }
    }
    public void ActiveReloadText()
    {
        reload_text.SetActive(true);
    }
    public void Deactivation()
    {
        reload_text.SetActive(false);
    }
}
