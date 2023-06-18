using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FPS_mobile : MonoBehaviour
{
    public int speed;
    public FixedJoystick joystick;
    public CharacterController charactercontroller;
    public Camera main_camera;
    private bool isJumping;
    private float gravity = 10f;
    private float jumpTimer = 0f;
    private float jumpTime = 1f;
    private float jumpHeight = 6f;
    private float verticalspeed;
    public GameObject bazooka;
    public AudioSource source;
    public AudioClip sound_reload;
    public AudioClip first_aid_kit;
     //Health script
    public float maxHealth = 100f;
    public float currentHealth = 0f;
    public float damage = 1f;
    public HealthBar hb;
    public Image blood;
    Color alphaColor;
    public GameObject door_model;
    public GameObject hint_text;
    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;
        charactercontroller = GetComponent<CharacterController>();
        currentHealth = maxHealth;
        alphaColor = blood.color;
        hb.SetHealth(currentHealth);
        hint_text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        charactercontroller.Move(move * speed * Time.deltaTime);
    
        if(isJumping)
        {
            charactercontroller.Move(new Vector3(0f, verticalspeed, 0f) * Time.deltaTime);
            verticalspeed -= gravity * Time.deltaTime;
            if(charactercontroller.isGrounded)
            {
                isJumping = false;
            }
        }else if(!charactercontroller.isGrounded)
        {
            charactercontroller.Move(new Vector3(0f, verticalspeed, 0f) * Time.deltaTime);
            verticalspeed -= gravity * Time.deltaTime;
        }else {
            isJumping = false;
        }
    }

    public void Jump()
    {
        if(isJumping || !charactercontroller.isGrounded)
        {
            return;
        }
        isJumping = true;
        verticalspeed = jumpHeight;
    }
    public void CroachDown()
    {
        charactercontroller.height = 1f;
        main_camera.transform.localPosition = new Vector3(0, -0.36f, 0);
    }
    public void CroachUp()
    {
        charactercontroller.height = 2f;
        main_camera.transform.localPosition = new Vector3(0, 0.2367195f, 0);
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
    public void TakeDamageFromTank(float damage)
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
            if(bazooka.GetComponent<Bazooka_mobile>().current_ammo == 0)
            {
                source.PlayOneShot(sound_reload);
                bazooka.GetComponent<Bazooka_mobile>().current_ammo = 3;
                bazooka.GetComponent<Bazooka_mobile>().reload_text.GetComponent<Text>().text = "Bazooka Ammo: " + bazooka.GetComponent<Bazooka_mobile>().current_ammo.ToString();
            }
        }
        
        if(hit.collider.CompareTag("door"))
        {
                print("rabotaet");
                //GameObject door_model = GameObject.Find("OpenDoor");
                door_model.GetComponent<Animator>().SetBool("Open_door", true);
        }
        if(hit.collider.CompareTag("MedKit"))
        {
            StartCoroutine(show_hint());
            if(Input.GetKeyDown(KeyCode.E))
            {
                hint_text.SetActive(false);
                source.PlayOneShot(first_aid_kit);
                currentHealth = maxHealth;
                hb.SetHealth(currentHealth);
            }
        }
    }
    IEnumerator show_hint()
    {
        hint_text.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        hint_text.SetActive(false);
    }
}
