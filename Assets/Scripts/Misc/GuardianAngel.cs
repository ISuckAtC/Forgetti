using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianAngel : MonoBehaviour
{

    [Tooltip("Leave empty to use Rigidbody on same object")]
    public Rigidbody rb;
    private Vector3 spawnPos;

    private void Start()
    {

        spawnPos = transform.position;

    }

    private void FixedUpdate()
    {

        if(transform.position.y < -5)
        {

            Debug.Log("Deploying Guardin Angle");
            if(!rb)
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            else
                rb.velocity = Vector3.zero;

            transform.position = spawnPos;


        }

    }

}
