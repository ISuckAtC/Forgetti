using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicController : MonoBehaviour
{
    public float RotationSpeed;
    public float MovementSpeed;
    private Rigidbody rb;
    public Transform PlayerCamera;
    public float InteractRange;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * RotationSpeed, Space.Self);
        PlayerCamera.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * (RotationSpeed / 3), Space.Self);
        rb.velocity = (((transform.right * movement.x) + (transform.forward * movement.y)).normalized * MovementSpeed) + new Vector3(0, rb.velocity.y, 0);


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit rayhit;
            if (Physics.Raycast(transform.position, transform.forward, out rayhit, InteractRange))
            {
                Debug.Log("Interaction ray hit " + rayhit.transform.name);
                if (rayhit.transform.tag == "Door") rayhit.transform.GetComponent<Door>().Interact();
            }
        }
    }
}
