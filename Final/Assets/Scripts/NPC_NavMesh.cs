using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_NavMesh : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public NavMeshAgent navmesh;
    public bool stop;
    public bool goToObjectOne;
    // Start is called before the first frame update
    void Start()
    {
        stop = false;
        goToObjectOne = true;
        GetComponent<Enemy>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stop == false)
        {
            if (goToObjectOne == true)
            {
                navmesh.destination = target.position;
            }
            else
            {
                navmesh.destination = target2.position;
            }
        }
    }

    
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("FS");
        StartCoroutine(Stopping());
    }

    IEnumerator Stopping()
    {
        stop = true;
        goToObjectOne = !goToObjectOne;
        GetComponent<Enemy>().enabled = true;
        yield return new WaitForSeconds(6);
        stop = false;
        GetComponent<Enemy>().enabled = false;

    }


}
