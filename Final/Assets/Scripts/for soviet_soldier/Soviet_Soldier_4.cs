using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soviet_Soldier_4 : MonoBehaviour
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
            animator.SetBool("rifle_idle_two", true);
        }else {
            animator.SetBool("rifle_idle_two", false);
        }
    }
}
