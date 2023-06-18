using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float fireRate = 1f;
    public float damage;
    public Animator anim;
    private float nextFireTime = 0f;
    public AudioSource source;
    public AudioClip fire_sound;
    public AudioClip hurt_sound;

    void Start() 
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
          if(Time.time > nextFireTime) 
          {
            nextFireTime = Time.time + 1f / fireRate;
            ShootEnemy();
          }
    }
    public void ShootEnemy() 
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 200f)) {
            //PlaySound();
            if (hit.transform.CompareTag("Player")) {
                anim.SetBool("shoot_enemy", true);
                hit.transform.GetComponent<FPS_first_level>().TakeDamage();
                hit.transform.GetComponent<FPS_mobile>().TakeDamage();
            }else
            anim.SetBool("shoot_enemy", false);
            FPS_first_level fps = hit.transform.GetComponent<FPS_first_level>();
            FPS_mobile fps_mobile = hit.transform.GetComponent<FPS_mobile>();
            if(fps_mobile != null)
            {
                source.PlayOneShot(hurt_sound);
            }
        }
    }
    void PlaySound()
    {
        source.PlayOneShot(fire_sound);
    }
}
