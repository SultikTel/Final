using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_first_level : MonoBehaviour
{
    public float speed;
    public float jumpHeight = 1.0f;
    public float jumpTime = 0.5f;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    public bool isJumping = false;
    private float jumpVelocity = 0.0f;
    private float gravity = -9.8f;
    public CharacterController controller;
    private Vector3 velocity;
    public Transform CheckGround;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal  = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * speed * Time.deltaTime);

        bool isGrounded = Physics.CheckSphere(CheckGround.position, groundDistance, groundMask);
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            jumpVelocity = Mathf.Sqrt(-2.0f * gravity * jumpHeight);
        }
        if(isGrounded && velocity.y < 0)
        {
            isJumping = false;
            velocity.y = -2f;
        }
        if(isJumping)
        {
            controller.Move(Vector3.up * (jumpVelocity * Time.deltaTime));
            jumpVelocity += gravity * Time.deltaTime;
        }
         //SitDown
        if(Input.GetKey(KeyCode.C))
        {
            controller.height = 1f;
            cam.transform.localPosition = new Vector3(0, -0.36f, 0);
        }else {
            controller.height = 2f;
             cam.transform.localPosition = new Vector3(0, 0.2367195f, 0);
        }
    }

}
