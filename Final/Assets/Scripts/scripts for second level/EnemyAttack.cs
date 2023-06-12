using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float fireRate = 1f;
    public float damage = 1f;
    public float range;
    public Transform player;
    public Animator anim;
    private float nextFireTime = 0f;
    public AudioSource source;
    public AudioClip fire_sound;
    public AudioClip hurt_sound;
    public bool isAttack;
    public GameObject FPS;
    //public bool isAttack;
    void Start() 
    {
        anim = GetComponent<Animator>();
        isAttack = false;
    }
    // Update is called once per frame
    void Update()
    {
          if(Time.time > nextFireTime) 
          {
            nextFireTime = Time.time + 1f / fireRate;
            ShootEnemy();
          }

          LookAtFps();
    }
    public void ShootEnemy() 
    {
        // anim.SetBool("shoot_enemy", true);
        isAttack = true;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range)) {
            if (hit.transform.CompareTag("Player")) {
                hit.transform.GetComponent<Sniper>().TakeDamage();
                PlaySound();
            }
            Sniper sniper = hit.transform.GetComponent<Sniper>();
            if(sniper != null)
            {
                source.PlayOneShot(hurt_sound);
            }
        }
        isAttack = false;
    }
    void LookAtFps()
    {
        if(isAttack)
        {
            transform.LookAt(FPS.transform.position);
        }
    }
    void PlaySound()
    {
        source.PlayOneShot(fire_sound);
    }
}
