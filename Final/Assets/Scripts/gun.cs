using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Animator animator;
    public Camera MainCamera;
    public ParticleSystem fire;
    public GameObject bullet_impact;
    public AudioClip sound;
    public AudioClip sound2;
    //other scripts
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        fire.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        //shoot
        if(Input.GetMouseButtonDown(0))
        {
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
        if(Input.GetKeyDown(KeyCode.R)) 
        {
            animator.SetBool("reload", true);
            gm.PlaySound(sound2);
        }
        //walking
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("walking", true);
        }else {
            animator.SetBool("walking", false);
        }

       //Aim
       if(Input.GetMouseButtonDown(1)){
          MainCamera.fieldOfView = 51;
       }
       if(Input.GetMouseButtonUp(1)){
          MainCamera.fieldOfView = 71;
       }
    }
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out hit, 100))
        {
            Debug.Log(hit.transform.name);
            
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * 50);
            }
            GameObject impact_clone = Instantiate(bullet_impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact_clone, 1.5f);   
        }
    }
}
