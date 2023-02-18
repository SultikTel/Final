using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Animator animator;
    public Camera MainCamera;
    public ParticleSystem fire;
    public ParticleSystem bullet_impact;
    public AudioClip sound;
    //other scripts
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        fire.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
            fire.Play();
            gm.PlaySound(sound);
        }

       //Aim
       if(Input.GetMouseButtonDown(1)){
          animator.SetBool("aim", true);
          MainCamera.fieldOfView = 50;
       }
       if(Input.GetMouseButtonUp(1)){
          animator.SetBool("aim", false);
          MainCamera.fieldOfView = 60;
       }
    }
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out hit, 100))
        {
            Debug.Log(hit.transform.name);

            Instantiate(bullet_impact, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
