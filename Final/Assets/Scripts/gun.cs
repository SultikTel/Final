using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gun : MonoBehaviour
{
    public Animator animator;
    public Camera MainCamera;
    public ParticleSystem fire;
    public GameObject bullet_impact;
    public AudioSource gameManager;
    public AudioClip shoot;
    public AudioClip sound2;
    public AudioSource walking_sound;
    public GameObject message1;
    public int current_ammo;
    public int max_ammo = 5;
    public int damage;
    private bool isReloading = false;
    public bool onPause;
    public Text ammo_text;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        fire.Stop();
        onPause = false;
        message1.SetActive(false);
        current_ammo = max_ammo;
        ammo_text.text = "Kalashnik Ammo: " + current_ammo.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if(onPause == false){
        //shoot
        if(Input.GetMouseButtonDown(0) && current_ammo > 0)
        {
            current_ammo -= 1;
            ammo_text.text = "Kalashnik Ammo: " + current_ammo.ToString();
            Shoot(); //Active shoot function
            fire.Play(); //particle system fire
            gameManager.PlayOneShot(shoot); // sound while shooting
            animator.SetBool("shoot", true); //animation for shoot
        }
        if(Input.GetMouseButtonUp(0)) 
        {
            animator.SetBool("shoot", false);
        }

        //Reload
        if(isReloading) 
           return;
        if(current_ammo == 0) 
        {
            PlaySoundReload();
            StartCoroutine(Reloading());
            return;
        }

        //walking animation
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("walking", true);
            //walking_sound.Play();
        }else {
            animator.SetBool("walking", false);
        }

       //Aim animation
       if(Input.GetMouseButtonDown(1)){
          MainCamera.fieldOfView = 41;
       }
       if(Input.GetMouseButtonUp(1)){
          MainCamera.fieldOfView = 71;
       }
    }
       if(Input.GetKeyDown(KeyCode.Escape))
       {
        onPause = !onPause;
       }
    }
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out hit, 100))
        {
            //Debug.Log(hit.transform.name); //to print of name gameobject to triggered by weapon


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
    public IEnumerator Reloading()
    {
        isReloading = true;
        message1.SetActive(true);
        animator.SetBool("reload", true);
        yield return new WaitForSeconds(3f);
        current_ammo = max_ammo;
        ammo_text.text = "Kalashnik Ammo: " + current_ammo.ToString();
        animator.SetBool("reload", false);
        message1.SetActive(false);
        isReloading = false;
    }
}
