using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soviet_Soldier_3 : MonoBehaviour
{
    public Animator animator;
    public bool anim_bool = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        anim_bool = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(anim_bool == true)
        {
            animator.SetBool("idle_crouching", true);
        }else {
            animator.SetBool("idle_crouching", false);
        }
    }
}
