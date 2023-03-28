using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoing : MonoBehaviour
{
    public EnemyBySultan[] enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = Object.FindObjectsOfType<EnemyBySultan>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
