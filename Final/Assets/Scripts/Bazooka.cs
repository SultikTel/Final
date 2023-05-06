using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bazooka : MonoBehaviour
{
    public Camera MainCamera;
    public int current_ammo;
    public int magazine = 3;
    public int count;
    public GameManager gamemanager;
    public AudioClip shoot;
    public ParticleSystem fire;
    public ParticleSystem Vzriv;
    public GameObject bullet_impact;
    public bool exploded;
    public GameObject panzer;
    public GameObject panzer_destroyed;
    // Start is called before the first frame update
    void Start()
    {
        fire.Stop();
        Vzriv.Stop();
        current_ammo = magazine;
        exploded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && current_ammo > 0)
        {
            Shoot();
            fire.Play();
            gamemanager.PlaySound(shoot);
            current_ammo -= 1;
        }
        if(count == 3 && exploded == false)
        {
            Vzriv.Play();
            exploded = true;
            StartCoroutine(Panzer_death());
        }
    }
    IEnumerator Panzer_death()
    {
        yield return new WaitForSeconds(.7f);
        panzer.SetActive(false);
        panzer_destroyed.SetActive(true);
        Instantiate(panzer_destroyed, panzer.transform.position, panzer.transform.rotation);

    }
    void Shoot()
    {
        if(Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out RaycastHit Hitinfo, 100))
        {
            Debug.Log(Hitinfo.transform.name);
            
            if(Hitinfo.transform.CompareTag("Panzer"))
            {
                count += 1;
            }
            if(Hitinfo.rigidbody != null)
            {
                Hitinfo.rigidbody.AddForce(-Hitinfo.normal * 80);
            }

            GameObject impact_clone = Instantiate(bullet_impact, Hitinfo.point, Quaternion.LookRotation(Hitinfo.normal));
            Destroy(impact_clone, 1.5f);
        }
    }
}
