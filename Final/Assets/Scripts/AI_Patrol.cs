using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Patrol : MonoBehaviour
{
    public NavMeshAgent agent;
    int i;
    public List<Transform> target;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.transform.position == agent.pathEndPosition)
        {
            TargetsUpdate();
        }
        agent.SetDestination(target[i].position);
    }
    void TargetsUpdate()
    {
        i = Random.Range(0, target.Count);
    }
}
