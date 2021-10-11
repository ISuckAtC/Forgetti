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
    private bool reverse;

    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation.eulerAngles.y;
        pivotPoint = transform.position + (transform.forward * PivotDistance);
        Links = SetLinks;
    }

    void FixedUpdate()
    {
        if (open)
        {
            float delta = Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.y, startRotation + (reverse ? -RotateAmount : RotateAmount)));
            if (delta != 0)
            {
                transform.RotateAround(pivotPoint, Vector3.up, delta < RotateSpeed ? (reverse ? -delta : delta) : (reverse ? -RotateSpeed : RotateSpeed));
                //transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.MoveTowards(transform.rotation.eulerAngles.y, startRotation + RotateAmount, RotateSpeed), transform.eulerAngles.z);
            }
        }
        else
        {
            float delta = Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.y, startRotation));
            if (delta != 0)
            {
                transform.RotateAround(pivotPoint, Vector3.up, delta < RotateSpeed ? (reverse ? delta : -delta) : (reverse ? RotateSpeed : -RotateSpeed));
                //transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.MoveTowards(transform.rotation.eulerAngles.y, startRotation, RotateSpeed), transform.eulerAngles.z);
            }
        }
    }

    public void Interact(bool chain = false)
    {
        if (!open)
        {
            Vector2 difference = new Vector2(BasicController.Player.transform.position.x - transform.position.x, BasicController.Player.transform.position.z - transform.position.z);
            Vector2 direction = new Vector2(transform.right.x, transform.right.z);
            difference = difference.normalized;
            direction = direction.normalized;
            float vectorDistance = Vector2.Distance(difference, direction);
            Debug.Log(transform.right);
            Debug.Log(difference + " | " + direction + " | " + vectorDistance);
            if (vectorDistance > 1.618033988f) // Golden Ratio
            {

            }
        }
        open = !open;
        if (!chain)
        {
            foreach(GameObject o in Links) o.GetComponent<Door>().Interact(true);
        }
        Debug.Log("Interacted with " + name);
    }
}
