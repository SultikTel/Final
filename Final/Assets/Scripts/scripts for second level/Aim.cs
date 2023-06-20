using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Aim : MonoBehaviour
{
    public GameObject zoom;
    public Camera camera;
    bool onZoom;
    // Start is called before the first frame update
    void Start()
    {
        zoom.SetActive(false);
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            zoom.SetActive(true);
            camera.fieldOfView = 10f;
        }
        if(Input.GetMouseButtonUp(1))
        {
            zoom.SetActive(false);
            camera.fieldOfView = 93f;
        }
    }
}
