using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Player : MonoBehaviour
{
    public float speed;
    bool isGrounded;
    public float jumpForce;
    Rigidbody rb;
    public DialogueManager dialoguemanager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
        isGrounded = true;    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
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
        isGrounded = true;

        if(collision.gameObject.tag == "soldier")
        {
            dialoguemanager.StartDialogue();
            dialoguemanager.isActive = true;
        }
    }
    
}
