using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Aim : MonoBehaviour
{
    public GameObject zoom;
    public Camera camera;
    public Image target;
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
            camera.fieldOfView = 8f;
            target.enabled = false;
        }
        if(Input.GetMouseButtonUp(1))
        {
            zoom.SetActive(false);
            camera.fieldOfView = 93f;
            target.enabled = true;
        }
    }
}
