﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS_first_level : MonoBehaviour
{
    public float speed;
    private float jumpHeight = 1.0f;
    private float jumpTime = 0.5f;
    private float groundDistance = 0.2f;
    public LayerMask groundMask;
    public bool isJumping = false;
    private float jumpVelocity = 0.0f;
    private float gravity = -9.8f;
    public CharacterController controller;
    private Vector3 velocity;
    public Transform CheckGround;
    public Camera camera;
    public GameObject bazooka;
    public AudioSource source;
    public AudioClip sound_reload;
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
    void FixedUpdate()
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

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.CompareTag("Bullets"))
        {
            if(bazooka.GetComponent<Bazooka2>().current_ammo == 0)
            {
                print("work");
                source.PlayOneShot(sound_reload);
                bazooka.GetComponent<Bazooka2>().current_ammo = 3;
                bazooka.GetComponent<Bazooka2>().reload_text.GetComponent<Text>().text = "Bazooka Ammo: " + bazooka.GetComponent<Bazooka2>().current_ammo.ToString();
            }
        }
    }
}
