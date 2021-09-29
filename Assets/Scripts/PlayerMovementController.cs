using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    public float MovementSpeed, JumpHeight, GroundCheckCooldown;
    [SerializeField]
    private float jumping, sprinting, groundCheckCD;
    [SerializeField]
    private bool grounded;
    private Vector3 movementDir, spawnOrigin;
    private Rigidbody rb;
    private Transform camTransform;
    private LayerMask playerMask;
    private CameraController cc;

    void Start()
    {

        cc = Camera.main.GetComponent<CameraController>();
        rb = gameObject.GetComponent<Rigidbody>();
        camTransform = Camera.main.transform;
        playerMask = 1 << LayerMask.NameToLayer("Player");
        spawnOrigin = transform.position;

    }

    void Update()
    {

        if(transform.position.y < -5)
        {

            rb.velocity = Vector3.zero;
            transform.position = spawnOrigin;

        }

        if(Physics.SphereCast(transform.position, 0.5f, Vector3.down, out RaycastHit groundCheck, 1.05f, ~playerMask, QueryTriggerInteraction.Ignore) && groundCheckCD <= 0)
        {

            grounded = true;

        }
        else
        {

            grounded = false;

        }

        if(Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {

            if(rb.velocity.y < 0)
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            
            jumping = 1;
            grounded = false;
            groundCheckCD = GroundCheckCooldown;

        }
        else jumping = 0;

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0)
        {

            sprinting = 1.25f;
            cc.Sprinting = true;

        }
        else
        {

            sprinting = 1;
            cc.Sprinting = false;

        }

        if(grounded == true || jumping != 0)
        {

            movementDir = (transform.forward * sprinting * Input.GetAxis("Vertical") * MovementSpeed) + new Vector3(0, rb.velocity.y + (jumping * JumpHeight), 0) + (transform.right * sprinting * Input.GetAxis("Horizontal") * MovementSpeed);

        }
        else
        {

            movementDir = rb.velocity;
            groundCheckCD -= Time.deltaTime;

        }

        rb.velocity = movementDir;
        

    }

}
