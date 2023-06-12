using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soviet_Soldier_2 : MonoBehaviour
{
    public Animator animator;
    public bool anim_bool = false;
    public FPS_first_level fps;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        anim_bool = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(fps.currentHealth != 100)
        {
            animator.SetBool("GunPlay", true);
        }
    }
}
