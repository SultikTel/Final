using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
   public float fireRate = 2f;
    public float damage = 1f;
    public float range = 25f;
    public Transform player;
    private float nextFireTime = 0f;
    public AudioSource source;
    public AudioClip fire_sound;
    public AudioClip hurt_sound;
    public ParticleSystem fire;
    public GameObject vzriv;
    void Start() 
    {
    }
    // Update is called once per frame
    void Update()
    {
          if(Time.time > nextFireTime) 
          {
            nextFireTime = Time.time + 15f / fireRate;
            ShootEnemy();
          }
    }
    public void ShootEnemy() 
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range)) {
            fire.Play();
            PlaySound();
            if (hit.transform.CompareTag("Player")) {
                hit.transform.GetComponent<FPS_first_level>().TakeDamage();
            }else{
            FPS_first_level first_person_shooter = hit.transform.GetComponent<FPS_first_level>();
            if(first_person_shooter != null)
            {
                source.PlayOneShot(hurt_sound);
            }
          }
          Instantiate(vzriv, hit.transform.position, hit.transform.rotation);
        }
    }
    void PlaySound()
    {
        source.PlayOneShot(fire_sound);
    }
}
