using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalDoor : MonoBehaviour, IInteractable
{
    private bool open;
    private float startRotation;
    public float RotateAmount;
    public float RotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation.eulerAngles.x;
    }

    void FixedUpdate()
    {
        if (open)
        {
            float delta = Mathf.DeltaAngle(transform.rotation.eulerAngles.x, startRotation + RotateAmount);
            if (delta != 0)
            {
                transform.Rotate(transform.right, (delta < RotateSpeed ? delta : RotateSpeed));
                //transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.MoveTowards(transform.rotation.eulerAngles.y, startRotation + RotateAmount, RotateSpeed), transform.eulerAngles.z);
            }
        }
        else
        {
            float delta = Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.x, startRotation));
            if (delta != 0)
            {
                Debug.Log(delta);
                transform.Rotate(delta < RotateSpeed ? -delta : -RotateSpeed, 0, 0, Space.World);
                //transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.MoveTowards(transform.rotation.eulerAngles.y, startRotation, RotateSpeed), transform.eulerAngles.z);
            }
        }
    }

    public void Interact()
    {
        open = !open;
        Debug.Log("Interacted with " + name);
    }
}
