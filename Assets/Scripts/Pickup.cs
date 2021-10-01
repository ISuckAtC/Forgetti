using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Transform playerCam;    
    private float distance;
    private float velocityMultiplier;
    private Rigidbody rb;
    
    public void Initialize(Transform _playerCam, float _distance, float _velocityMultiplier)
    {
        playerCam = _playerCam;
        distance = _distance;
        velocityMultiplier = _velocityMultiplier;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = playerCam.position + (playerCam.forward * distance);
        rb.velocity = (targetPosition - transform.position) * distance * velocityMultiplier;
    }
}
