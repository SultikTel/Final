using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public NavMeshAgent navmesh;
    public bool goTo1;
    public bool stay;

    // Start is called before the first frame update
    void Start()
    {
        goTo1 = true;
        stay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stay == false)
        {
            if (goTo1 == true)
            {
                navmesh.destination = target1.position;
            }
            else
            {
                navmesh.destination = target2.position;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        ReachedTarget();

    }

    public void ReachedTarget()
    {
        goTo1 = !goTo1;
        StartCoroutine(Reached());
    }

    IEnumerator Reached()
    {
        stay = true;
        yield return new WaitForSeconds(5);
        stay = false;

    }
}
