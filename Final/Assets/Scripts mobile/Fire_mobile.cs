using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fire_mobile : MonoBehaviour
{
    public Animator animator;
    public Camera Main_Camera;
    public ParticleSystem fire;
    public GameObject bullet_impact;
    public AudioSource source;
    public AudioClip shoot;
    public AudioClip sound2;
    public GameObject message1;
    public int current_ammo;
    public int max_ammo;
    public int damage;
    private bool isReloading = false;
    public Text ammo_text;
    private bool isActiveFire = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        fire.Stop();
        message1.SetActive(false);
        current_ammo = max_ammo;
        ammo_text.text = "Kalashnik Ammo: " + current_ammo.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        //shoot
        if(isActiveFire && current_ammo > 0)
        {
            Shoot(); //Active shoot function
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
        }else {
            animator.SetBool("walking", false);
        }
    }
    public void AimDown()
    {
        Main_Camera.fieldOfView = 41;
    }
    public void AimUp()
    {
        Main_Camera.fieldOfView = 71;
    }
    public void Shoot()
    {
        isActiveFire = true;
        RaycastHit hit;
        if(Physics.Raycast(Main_Camera.transform.position, Main_Camera.transform.forward, out hit, 100))
        {
            //Debug.Log(hit.transform.name); //to print of name gameobject to triggered by weapon
            current_ammo -= 1;
            ammo_text.text = "Kalashnik Ammo: " + current_ammo.ToString();
            fire.Play();
            source.PlayOneShot(shoot); 
            //animator.SetBool("shoot", true); //animation for shoot  

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
            isActiveFire = false;
        }
    }
    void PlaySoundReload()
    {
        source.PlayOneShot(sound2); 
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