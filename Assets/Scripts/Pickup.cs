using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Transform playerCam;    
    public float Distance;
    private float velocityMultiplier;
    private Rigidbody rb;
    
    public void Initialize(Transform _playerCam, float _distance, float _velocityMultiplier)
    {
        playerCam = _playerCam;
        Distance = _distance;
        velocityMultiplier = _velocityMultiplier;
        rb = GetComponent<Rigidbody>();
        Debug.Log("Picked up " + name);
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = playerCam.position + (playerCam.forward * Distance);
        if (!rb)
        {
            Debug.Log("RB destroyed, nuking this object");
            Destroy(gameObject);
        }
        rb.velocity = (targetPosition - transform.position) * Distance * velocityMultiplier;
    }
}
