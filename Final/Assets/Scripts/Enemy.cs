using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float fireRate = 1f;
    public float damage;
    public Animator anim;
    public Transform fps;
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
          transform.LookAt(fps.transform.position);
    }
    public void ShootEnemy() 
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 200f)) {
            if (hit.transform.CompareTag("Player")) {
                anim.SetBool("shoot_enemy", true);
                  PlaySound();
                hit.transform.GetComponent<FPS_first_level>().TakeDamage();
            }else
            anim.SetBool("shoot_enemy", false);
            FPS_first_level fps = hit.transform.GetComponent<FPS_first_level>();
            if(fps != null)
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
