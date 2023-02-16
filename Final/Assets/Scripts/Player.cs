using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed;
    public Rigidbody rb;
    public DialogueManager dialoguemanager;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //basic movement
       float x = Input.GetAxis("Horizontal");
       float z = Input.GetAxis("Vertical");
       Vector3 move = new Vector3(x, 0, z);
       rb.velocity = move * speed;

       
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "soldier")
        {
            dialoguemanager.StartDialogue();
        }
    }
}
