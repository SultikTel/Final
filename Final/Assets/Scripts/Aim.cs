using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Animator animator;
    public Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
