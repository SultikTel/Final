using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBySultan : MonoBehaviour
{
    [SerializeField]
    public bool isFirstwave;

    public void getAlive()
    {
        gameObject.SetActive(true);
    }

    public void getFade()
    {
        gameObject.SetActive(false);
    }
}
