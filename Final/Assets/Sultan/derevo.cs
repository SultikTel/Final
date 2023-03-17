using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class derevo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        byte c = 0;
        foreach (Material matt in gameObject.GetComponent<MeshRenderer>().materials)
        {
            if (matt.name.Contains("Leaves_3"))
            {
                matt.SetColor("_HueVariation", new Color32(255, 255, 255, c));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
