using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //This script controls the players camera and their Field of view when running.

    public bool Sprinting;
    public float InputSensitivity;
    private float xRot, fov;
    Transform player;

    void Start()
    {

        fov = Camera.main.fieldOfView;
        Cursor.lockState = CursorLockMode.Locked;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    void Update()
    {

        player.Rotate(Vector3.up, Input.GetAxisRaw("Mouse X") * InputSensitivity);
        xRot -= Input.GetAxisRaw("Mouse Y") * InputSensitivity;
        xRot = Mathf.Clamp(xRot, -90, 90);
        transform.localEulerAngles = new Vector3(xRot, 0, 0);

        if(Sprinting)
        {

            Camera.main.fieldOfView = fov + 10;

        }
        else
        {

            Camera.main.fieldOfView = fov;

        }

    }

}
