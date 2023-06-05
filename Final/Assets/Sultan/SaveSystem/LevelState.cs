using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelState 
{
    
    public float[] playerPosition;
    public float playerHealth;
    

    public LevelState(LevelGoing level, FPS_first_level fps)
    {
        
        playerPosition[0] = fps.transform.position.x;
        playerPosition[1] = fps.transform.position.y;
        playerPosition[2] = fps.transform.position.z;

        playerHealth = fps.currentHealth;



    }
}
