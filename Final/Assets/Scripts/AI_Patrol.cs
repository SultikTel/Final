using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Patrol : MonoBehaviour
{
    public float speed;
    public Transform[] points;
    int random_point;
    // Start is called before the first frame update
    void Start()
    {
        random_point = Random.Range(0, points.Length); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[random_point].position, speed * Time.deltaTime);
        if(transform.position == points[random_point].position)
        {
            random_point = Random.Range(0, points.Length);
        }
    }

}
