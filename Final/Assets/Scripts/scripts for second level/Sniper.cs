using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sniper : MonoBehaviour
{
   public float speed;
    private float jumpHeight = 1.0f;
    //private float jumpTime = 0.5f;
    private float groundDistance = 0.2f;
    public LayerMask groundMask;
    public bool isJumping = false;
    private float jumpVelocity = 0.0f;
    private float gravity = -9.8f;
    public CharacterController controller;
    private Vector3 velocity;
    public Transform CheckGround;
    public Camera camera;

    //Health script
    public float maxHealth = 100f;
    public float currentHealth = 0f;
    public float damage = 1f;
    public HealthBar hb;
    public Image blood;
    Color alphaColor;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        alphaColor = blood.color;
        hb.SetHealth(currentHealth);
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
        if(isGrounded && velocity.y > 10f)
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

            camera.transform.localPosition = new Vector3(0, -0.36f, 0);
        }else {
            controller.height = 2f;

             camera.transform.localPosition = new Vector3(0, 0.2367195f, 0);
        }

        
        
    }
    public void TakeDamage()
    {
        currentHealth -= damage;
        hb.SetHealth(currentHealth);
        StartCoroutine(BloodEffect());
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        print("Player is dead");
    }
    IEnumerator BloodEffect()
    {
        alphaColor.a += .1f;
        blood.color = alphaColor;
        yield return new WaitForSeconds(5f);
        alphaColor.a -= .1f;
        blood.color = alphaColor;
    }
}

