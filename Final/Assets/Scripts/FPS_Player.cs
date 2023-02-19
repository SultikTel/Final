﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS_Player : MonoBehaviour
{
    public float speed;
    bool isGrounded;
    public float jumpForce;
    public GameObject aimActive;
    Rigidbody rb;
    public DialogueManager dialoguemanager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
        isGrounded = false;    
        aimActive.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            aimActive.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == false)
        {
            rb.AddForce(new Vector3(0, 3f, 0));
            isGrounded = true;
        }
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0f, vertical);
        transform.Translate(move * speed);
    }
    void OnCollisionEnter(Collision collision)
    {
        isGrounded = false;

        if(collision.gameObject.tag == "soldier")
        {
            dialoguemanager.StartDialogue();
            dialoguemanager.isActive = true;
        }
    }
    
}
