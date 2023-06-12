using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Fps : MonoBehaviour
{
    public float speed;
    public float damage = 1f;
    public float jumpHeight = 1.0f;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    public bool isJumping = false;
    private float jumpVelocity = 0.0f;
    private float gravity = -9.8f;
    public CharacterController controller;
    private Vector3 velocity;
    public Transform G_O;
    public Camera cam;

    public AudioClip clip;
    public Animator animator;
    public float Maxhealth = 100;
    public float currentHealth;
    public HealthBar hb;

    public move_npc npc1;
    public move_npc npc2;
    public move_npc npc3;
    public move_npc npc4;
    public move_npc npc5;
    public GameObject hint_object;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = Maxhealth;
        hb.SetMaxHealth(Maxhealth);
        hint_object.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Проверяем, находится ли объект на земле
        bool isGrounded = Physics.CheckSphere(G_O.position, groundDistance, groundMask);

        // Если объект на земле, то сбрасываем скорость прыжка и устанавливаем isJumping в false
        if (isGrounded && velocity.y < 10f)
        {
            velocity.y = -2f;
            isJumping = false;
        }

        // Если нажали на кнопку прыжка и объект на земле, то начинаем прыжок
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            jumpVelocity = Mathf.Sqrt(-2.0f * gravity * jumpHeight);
        }

        // Если объект прыгает, то продолжаем движение вверх
        if (isJumping)
        {
            controller.Move(Vector3.up * (jumpVelocity * Time.deltaTime));
            jumpVelocity += gravity * Time.deltaTime;
        }

        // Движение объекта с помощью CharacterController
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * speed*Time.deltaTime);

        // Применяем гравитацию к объекту
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //SitDown
        if(Input.GetKey(KeyCode.C))
        {
            controller.height = 1f;
            cam.transform.localPosition = new Vector3(0, -0.36f, 0);
        }else {
            controller.height = 2f;
             cam.transform.localPosition = new Vector3(0, 0.2367195f, 0);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            npc1.GetComponent<move_npc>().SetDestination = true;
            npc2.GetComponent<move_npc>().SetDestination = true;
            npc3.GetComponent<move_npc>().SetDestination = true;
            npc5.GetComponent<move_npc>().SetDestination = true;
            npc4.GetComponent<move_npc>().SetDestination = true;
            hint_object.SetActive(false);
        }
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.CompareTag("hint"))
        {
            hit.collider.gameObject.SetActive(false);
            hint_object.SetActive(true);
        }
    }
    public void TakeDamage()
    {
        currentHealth -= damage;
        hb.SetHealth(currentHealth);
        if(currentHealth <= 0){
            print("Игрок умер");
        }
    }
}
