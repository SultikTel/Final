using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaviMesh : MonoBehaviour
{
    public Transform place_one;
    public Transform place_two;
    public bool goPlaceOne;
    public bool canGo;
    public NavMeshAgent navmesh;
    // Start is called before the first frame update
    void Start()
    {
        
        ChangePosition();
    }

    // Update is called once per frame
    void Update()
    {
        navmesh.destination = place_one.position;
        
    }

    IEnumerator ChangePosition()
    {
        canGo = true;
        
        yield return new WaitForSeconds(8f);
        canGo = false;

        yield return new WaitForSeconds(5f);
        if (goPlaceOne)
        {
            goPlaceOne = false;
        }
        else
        {
            goPlaceOne = true;
        }

        ChangePosition();
    }
}
