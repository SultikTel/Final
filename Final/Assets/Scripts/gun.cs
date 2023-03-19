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
    public AudioClip sound;
    public AudioClip sound2;
    public AudioSource walking_sound;
    public GameObject message1;
    public int current_ammo;
    public int max_ammo = 5;
    public float damage;
    private bool isReloading = false;
    //other scripts
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        fire.Stop();
        message1.SetActive(false);
        current_ammo = max_ammo;
    }
    // Update is called once per frame
    void Update()
    {
        //shoot
        if(Input.GetMouseButtonDown(0) && current_ammo > 0)
        {
            current_ammo -= 1;
            Shoot(); //Active shoot function
            fire.Play(); //particle system fire
            gm.PlaySound(sound); // sound while shooting
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

        //walking
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("walking", true);
            //walking_sound.Play();
        }else {
            animator.SetBool("walking", false);
        }

       //Aim
       if(Input.GetMouseButtonDown(1)){
          MainCamera.fieldOfView = 51;
          animator.SetBool("aim", true);
       }else {
        animator.SetBool("aim", false);
       }
       if(Input.GetMouseButtonUp(1)){
          MainCamera.fieldOfView = 71;
       }

       // UI text
     
    }
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out hit, 100))
        {
            Debug.Log(hit.transform.name);
            
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
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
        gm.PlaySound(sound2);
    }
    IEnumerator Reloading()
    {
        isReloading = true;
        message1.SetActive(true);
        print("Reloading...");
        animator.SetBool("reload", true);
        yield return new WaitForSeconds(3f);
        current_ammo = max_ammo;
        animator.SetBool("reload", false);
        message1.SetActive(false);
        isReloading = false;
    }
}
