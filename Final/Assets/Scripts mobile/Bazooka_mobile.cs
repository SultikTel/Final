using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bazooka_mobile : MonoBehaviour
{
    private bool isFire;
    public Camera MainCamera;
    public int current_ammo;
    public int magazine;
    public int count;
    public GameManager2 gamemanager;
    public AudioClip shoot;
    public GameObject reload_text;
    public ParticleSystem fire;
    public ParticleSystem Vzriv;
    public GameObject vzriv_gameobject;
    public GameObject bullet_impact;
    private GameObject panzer;
    public GameObject panzer_destroyed;
    private bool exploded;

    //WaveController to count enemy otryad
    public GameObject wavecontroller;
    // Start is called before the first frame update
    void Start()
    {
        fire.Stop();
        Vzriv.Stop();
        isFire = false;
        current_ammo = magazine;
        exploded = false;
        reload_text.GetComponent<Text>().text = "Bazooka Ammo: " + current_ammo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFire && current_ammo > 0)
        {
            Shoot(); //Call method shoot     
        if (Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out RaycastHit Hitinfo, 100))
        {
            //Debug.Log(Hitinfo.transform.name);
            fire.Play(); //play particles
            gamemanager.PlaySound(shoot); //play sound shoot
            current_ammo -= 1;
            reload_text.GetComponent<Text>().text = "Bazooka Ammo: " + current_ammo.ToString();
            if (Hitinfo.transform.CompareTag("Panzer")) //to destroy tanks
            {
                count += 1;
                panzer = Hitinfo.transform.gameObject;
            }
            if(Hitinfo.transform.CompareTag("germans")) //to destroy germans soldier
            {
                print("germans");
                Target health_bar_enemy = Hitinfo.transform.GetComponent<Target>();
                health_bar_enemy.Die();
            }
            if (Hitinfo.rigidbody != null) // to make objects move from bullets
            {
                Hitinfo.rigidbody.AddForce(-Hitinfo.normal * 80);
            }

            GameObject impact_clone = Instantiate(bullet_impact, Hitinfo.point, Quaternion.LookRotation(Hitinfo.normal)); //to put effects billet impact
            Destroy(impact_clone, 1.5f);

            GameObject boom = Instantiate(vzriv_gameobject, Hitinfo.point, Quaternion.LookRotation(Hitinfo.normal)); //to put effect vzriv
            Destroy(boom, 2f);
            isFire = false;
        } 
        }
        if(current_ammo == 0)
        {
            isFire = false;
        }
        if (count == 3 && !exploded && panzer != null) //Check if our count bullets = 3 and he triggered by tank then play effects vzriv
        {
            wavecontroller.GetComponent<WaveController>().EnemyDead();
            exploded = false;
            count = 0;
            StartCoroutine(Panzer_death());
        }
    }

    IEnumerator Panzer_death()
    {
        Instantiate(Vzriv, panzer.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(.7f);
        panzer.SetActive(false);
        panzer_destroyed.SetActive(true);
        Instantiate(panzer_destroyed, panzer.transform.position, panzer.transform.rotation);
    }
    public void Shoot()
    {
        isFire = true;
    }
    public void ActiveReloadText()
    {
        reload_text.SetActive(true);
    }
    public void Deactivation()
    {
        reload_text.SetActive(false);
    }
}
