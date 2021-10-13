using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalDoor : MonoBehaviour, IInteractable
{
    public bool open;
    private float startRotation;
    public float RotateAmount;
    public float RotateSpeed;
    public GameObject[] Links {get; set;}
    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.localEulerAngles.x;
    }

    void FixedUpdate()
    {
        if (open)
        {
            float delta = Mathf.Abs(Mathf.DeltaAngle(transform.localEulerAngles.x, startRotation + RotateAmount));
            if (delta != 0)
            {
                if (delta < RotateSpeed) transform.localEulerAngles = new Vector3(startRotation + RotateAmount, transform.localEulerAngles.y, transform.localEulerAngles.z);
                else transform.Rotate(RotateSpeed, 0, 0, Space.Self);
                //transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.MoveTowards(transform.rotation.eulerAngles.y, startRotation + RotateAmount, RotateSpeed), transform.eulerAngles.z);
            }
        }
        else
        {
            float delta = Mathf.Abs(Mathf.DeltaAngle(transform.localEulerAngles.x, startRotation));
            if (delta != 0)
            {
                if (delta < RotateSpeed) transform.localEulerAngles = new Vector3(startRotation, transform.localEulerAngles.y, transform.localEulerAngles.z);
                else transform.Rotate(-RotateSpeed, 0, 0, Space.Self);
                //transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.MoveTowards(transform.rotation.eulerAngles.y, startRotation, RotateSpeed), transform.eulerAngles.z);
            }
        }
    }

    public void Interact(bool chain = false)
    {
        open = !open;
        Debug.Log("Interacted with " + name);
    }
}
