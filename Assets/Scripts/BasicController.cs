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
    public float PickupRange;
    public float HoldDistance;
    private GameObject heldObject;
    static public GameObject Player;

    void Start()
    {
        Player = gameObject;
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
            if (Physics.Raycast(PlayerCamera.position, PlayerCamera.forward, out rayhit, InteractRange))
            {
                Debug.Log("Interaction ray hit " + rayhit.transform.name);
                if (rayhit.transform.tag == "Door") rayhit.transform.GetComponent<IInteractable>().Interact();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (heldObject != null)
            {
                heldObject.GetComponent<Rigidbody>().useGravity = true;
                Destroy(heldObject.GetComponent<Pickup>());
                heldObject = null;
            }
            else
            {
                RaycastHit rayhit;
                if (Physics.Raycast(PlayerCamera.position, PlayerCamera.forward, out rayhit, PickupRange))
                {
                    Debug.Log("Pickup ray hit " + rayhit.transform.name);

                    if (rayhit.transform.tag == "Pickup")
                    {
                        Transform pickup = rayhit.transform;
                        pickup.gameObject.GetComponent<Rigidbody>().useGravity = false;
                        pickup.gameObject.AddComponent<Pickup>().Initialize(PlayerCamera, HoldDistance);
                        heldObject = pickup.gameObject;
                    }
                }
            }
        }
    }
}
