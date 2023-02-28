using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpsTrain : MonoBehaviour
{
    Animator animator;
    public Move player;
    

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = transform.parent.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            Walk();
        }
    }

    
    public void Crawl()
    {
        player.move = true;
        animator.SetInteger("AnimIndex", 3);
        
    }

    public void Jump()
    {
        player.move = true;
        animator.SetInteger("AnimIndex", 2);

    }

    public void Walk()
    {
        player.move = true;
        animator.SetInteger("AnimIndex", 1);

    }

    public void Idle()
    {
        player.move = false;
        animator.SetInteger("AnimIndex", 0);    

    }
    


}
