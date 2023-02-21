using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject weapon1;
    public GameObject weapon2;
    // Start is called before the first frame update
    void Start()
    {
        weapon2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            weapon1.SetActive(false);
            weapon2.SetActive(true);
        }   
    }
}
