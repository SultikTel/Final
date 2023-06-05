using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetFloat("Hp_onfirstSave"));

        Debug.Log(PlayerPrefs.GetFloat("X_onfirstSave"));
        Debug.Log(PlayerPrefs.GetFloat("Y_onfirstSave"));
        Debug.Log(PlayerPrefs.GetFloat("Z_onfirstSave"));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
