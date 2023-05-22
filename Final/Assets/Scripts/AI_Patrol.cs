using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Patrol : MonoBehaviour
{
    public float speed;
    public Transform[] points;
    int random_point;
    int new_point;
    bool stay = true;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        random_point = Random.Range(0, points.Length); 
        anim = GetComponent<Animator>();
        stay = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovingToDestination();

        if(transform.position == points[random_point].position)
        {
            if(stay == true){
            StartCoroutine(Stay());
            } 
        }
    }
    void MovingToDestination()
    {
            transform.position = Vector3.MoveTowards(transform.position, points[random_point].position, speed * Time.deltaTime);
            transform.LookAt(points[random_point].position);
    }
    IEnumerator Stay()
    {
        stay = false;
        yield return new WaitForSeconds(3f);
        while(new_point == random_point)
        {
          new_point = Random.Range(0, points.Length);  
        }
        random_point = new_point;
        stay = true;
    }
}
