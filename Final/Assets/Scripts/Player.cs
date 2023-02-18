using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    bool isGrounded;
    public GameObject targetActive;
    public Rigidbody rb;
    public DialogueManager dialoguemanager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
       //Active target img
       if(Input.GetKeyDown(KeyCode.F))
       {
          targetActive.SetActive(true);
       }
       if(Input.GetKeyDown(KeyCode.Space) && isGrounded == false){
          rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
          isGrounded = true;
       }
       
    }
    void FixedUpdate()
    {
        //basic movement
       float x = Input.GetAxis("Horizontal");
       float z = Input.GetAxis("Vertical");
       Vector3 move = new Vector3(x, 0, z);
       transform.Translate(move * speed);
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "soldier")
        {
            dialoguemanager.StartDialogue();
            dialoguemanager.isActive = true;
        }
        isGrounded = false;
    }
}
