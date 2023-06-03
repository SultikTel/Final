using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class move_npc : MonoBehaviour
{
    public Transform point;
    float speed = 1.5f;
    public bool SetDestination = false;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(SetDestination == true){
          transform.position = Vector3.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
          animator.SetBool("Crouching", true);
        }else 
        {
          SetDestination = false;
          animator.SetBool("Crouching", false);
        }
        if(transform.position == point.position)
        {
            SetDestination = false;
        }
    }
}
