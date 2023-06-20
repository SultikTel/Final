using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float mouseSensitivity;
    public Transform player;
    float xRotate = 0f; //чтобы отслеживать угол поворота вокруг оси х

    public bool onPause;
    // Start is called before the first frame update
    void Start()
    {
        onPause = false;
        //mouseSensitivity = PlayerPrefs.GetFloat("sensitivity");
    }

    // Update is called once per frame
    void Update()
    {

        if (onPause == false)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            xRotate = xRotate - mouseY;
            xRotate = Mathf.Clamp(xRotate, -30f, 30f); //для ограничения угла поворота в пределах от -30 до 30 градусов.

            transform.localRotation = Quaternion.Euler(xRotate, 0, 0); //для поворота камер вокруг оси X
            player.Rotate(Vector3.up * mouseX); //для поворота игрока вокруг оси Y используя входные данные от мыши MouseY
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onPause = !onPause;
        }
    }
}
