﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sniper_fire : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject bullet_impact;
    public AudioSource gameManager;
    public AudioClip shoot;
    public AudioClip sound2;
    public GameObject message1;
    public int current_ammo;
    public int max_ammo;
    public int damage;
    private bool isReloading = false;
    private bool onPause;
    // Start is called before the first frame update
    void Start()
    {
        onPause = false;
        message1.SetActive(false);
        current_ammo = max_ammo;
    }
    // Update is called once per frame
    void Update()
    {
        if (onPause == false)
        {
            //shoot
            if (Input.GetMouseButtonDown(0) && current_ammo > 0)
            {
                current_ammo -= 1;
                Shoot(); //Active shoot function
                gameManager.PlayOneShot(shoot); // sound while shooting
            }
            //Reload
            if (isReloading)
                return;
            if (current_ammo == 0)
            {
                PlaySoundReload();
                StartCoroutine(Reloading());
                return;
            }

        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {

            onPause = !onPause;
        }

    }
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out hit, 100))
        {
            Debug.Log(hit.transform.name); //to print of name gameobject to triggered by weapon

            //Edited by Sultan

            EnemyBySultan enemyBySultan = hit.collider.GetComponent<EnemyBySultan>();
            if (enemyBySultan != null)
            {
                enemyBySultan.die();
            }
            //the ended by sultan

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
            enemy_death enemy = hit.transform.GetComponent<enemy_death>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            HealthEnemy health_enemy = hit.transform.GetComponent<HealthEnemy>();
            if(health_enemy != null)
            {
                health_enemy.TakeDamage(damage);
            }
            
            
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * 50);
            }
            GameObject impact_clone = Instantiate(bullet_impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact_clone, 1.5f);   
        }
    }
    void PlaySoundReload()
    {
        gameManager.PlayOneShot(sound2); 
    }
    IEnumerator Reloading()
    {
        isReloading = true;
        message1.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        current_ammo = max_ammo;
        message1.SetActive(false);
        isReloading = false;
    }
}


