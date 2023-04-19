using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float fireRate = 1f;
    public float damage = 1f;
    public float range = 100f;
    public Transform player;
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
    void FixedUpdate()
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
        if (Physics.Raycast(transform.position, transform.forward, out hit, range)) {
            if (hit.transform.CompareTag("Player")) {
                anim.SetBool("shoot_enemy", true);
                hit.transform.GetComponent<FPS_first_level>().TakeDamage();
                PlaySound();
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
