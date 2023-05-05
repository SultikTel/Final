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
       
    }

    // Update is called once per frame
    void Update()
    {
        navmesh.destination = target.position;
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

    
   


}
