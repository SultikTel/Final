using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingCrawl : MonoBehaviour
{
    // Start is called before the first frame update

    public int operation;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NpsTrain>() != null)
        {
            if (operation == 0)
            {
                other.gameObject.GetComponent<NpsTrain>().Idle();
            }
            if (operation == 1) {
                other.gameObject.GetComponent<NpsTrain>().Walk(); 
            }
            if (operation == 2)
            {
                other.gameObject.GetComponent<NpsTrain>().Crawl();
            }
            if (operation == 3)
            {
                other.gameObject.GetComponent<NpsTrain>().Jump();
            }
        }

        


    }

    
   
}
