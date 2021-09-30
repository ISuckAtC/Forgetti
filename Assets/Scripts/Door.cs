using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool open;
    private float startRotation;
    public float RotateAmount;
    public float RotateSpeed;
    public float PivotDistance;
    private Vector3 pivotPoint;
    public GameObject[] Links {get; set;}
    public GameObject[] SetLinks;
    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation.eulerAngles.y;
        pivotPoint = transform.position + (transform.forward * PivotDistance);
        Links = SetLinks;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (open)
        {
            float delta = Mathf.DeltaAngle(transform.rotation.eulerAngles.y, startRotation + RotateAmount);
            if (delta != 0)
            {
                transform.RotateAround(pivotPoint, Vector3.up, delta < RotateSpeed ? delta : RotateSpeed);
                //transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.MoveTowards(transform.rotation.eulerAngles.y, startRotation + RotateAmount, RotateSpeed), transform.eulerAngles.z);
            }
        }
        else
        {
            float delta = Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.y, startRotation));
            if (delta != 0)
            {
                transform.RotateAround(pivotPoint, Vector3.up, delta < RotateSpeed ? -delta : -RotateSpeed);
                //transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.MoveTowards(transform.rotation.eulerAngles.y, startRotation, RotateSpeed), transform.eulerAngles.z);
            }
        }
    }

    public void Interact(bool chain = false)
    {
        open = !open;
        if (!chain)
        {
            foreach(GameObject o in Links) o.GetComponent<Door>().Interact(true);
        }
        Debug.Log("Interacted with " + name);
    }
}
