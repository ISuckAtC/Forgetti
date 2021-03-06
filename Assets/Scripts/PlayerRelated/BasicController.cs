using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicController : MonoBehaviour
{
    public float RotationSpeed;
    public float MovementSpeed;
    private Rigidbody rb;
    public Transform PlayerCamera;
    public float InteractRange;
    public float PickupRange;
    public float HoldDistance;
    public float MinDistance = 1;
    public float MaxDistance = 5;
    public float DistanceSensitivity = 1;
    public float HoldVelocityMultiplier;
    public GameObject HeldObject;
    public float HeldAngularDrag;
    static public GameObject Player;

    void Awake()
    {
        Player = gameObject;
    }
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
            if (Physics.Raycast(PlayerCamera.position, PlayerCamera.forward, out rayhit, InteractRange, ~0, QueryTriggerInteraction.Collide))
            {
                if (Input.GetKey(KeyCode.LeftShift)) Debug.Log("Interaction ray hit " + rayhit.transform.name);
                if (rayhit.transform.tag == "Board")
                {
                    rayhit.transform.parent.GetComponentInChildren<Dialogue>().Skip();
                }
            }
            if (Physics.Raycast(PlayerCamera.position, PlayerCamera.forward, out rayhit, InteractRange))
            {
                if (Input.GetKey(KeyCode.LeftShift)) Debug.Log("Interaction ray hit " + rayhit.transform.name);
                IInteractable interactable;
                if (rayhit.transform.TryGetComponent<IInteractable>(out interactable))
                {
                    interactable.Interact();
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (HeldObject != null)
            {
                HeldObject.GetComponent<Rigidbody>().useGravity = true;
                HeldObject.GetComponent<Rigidbody>().angularDrag = 0.05f;
                Destroy(HeldObject.GetComponent<Pickup>());
                HeldObject = null;
            }
            else
            {
                RaycastHit rayhit;
                if (Physics.Raycast(PlayerCamera.position, PlayerCamera.forward, out rayhit, PickupRange, ~0, QueryTriggerInteraction.Ignore))
                {
                    if (Input.GetKey(KeyCode.LeftShift)) Debug.Log("Pickup ray hit " + rayhit.transform.name);

                    if (rayhit.rigidbody && rayhit.rigidbody.transform.tag == "Pickup")
                    {
                        Transform pickup = rayhit.rigidbody.transform;
                        Rigidbody pickupBody = pickup.gameObject.GetComponent<Rigidbody>();
                        Anchored anchored;
                        if (pickup.TryGetComponent<Anchored>(out anchored))
                        {
                            anchored.Anchor.TempIgnore = pickup.gameObject;
                            pickupBody.isKinematic = false;
                            anchored.Anchor.Replace(null);
                        }
                        pickupBody.useGravity = false;
                        pickupBody.angularDrag = HeldAngularDrag;
                        pickup.gameObject.AddComponent<Pickup>().Initialize(PlayerCamera, HoldDistance, HoldVelocityMultiplier);
                        HeldObject = pickup.gameObject;
                    }
                }
            }
        }

        if (Input.mouseScrollDelta.y != 0 && HeldObject != null)
        {
            Pickup pickup = HeldObject.GetComponent<Pickup>();
            float newDistance = Mathf.Clamp(pickup.Distance + (Input.mouseScrollDelta.y * DistanceSensitivity), MinDistance, MaxDistance);
            pickup.Distance = newDistance;
        }
    }

    [ContextMenu("Move Up 1 Floor")]
    public void MoveUp()
    {
        transform.Translate(new Vector3(0, 10, 0));
    }

    [ContextMenu("Move Down 1 Floor")]
    public void MoveDown()
    {
        transform.Translate(new Vector3(0, -10, 0));
    }
    
}
