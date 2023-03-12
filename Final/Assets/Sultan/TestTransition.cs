using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestTransition : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadSec()
    {
        SceneManager.LoadScene("TraningLevel");
    }
}
