using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTask : MonoBehaviour , IInteractable
{

    public string TaskName;
    public GameObject[] Links {get; set;}

    public void Interact(bool chain = false)
    {

        Debug.Log("Picked up: " + gameObject.name);
        TaskManager.main.CompleteTask(TaskName);
        Destroy(gameObject, 0.2f);

    }

}
