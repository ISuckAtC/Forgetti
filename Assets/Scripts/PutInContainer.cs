using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutInContainer : MonoBehaviour
{

    public string TaskName;
    public GameObject[] ObjectsToStore;
    private int itemsStored;

    private void OnTriggerEnter(Collider col)
    {

        Debug.Log("hit " + col.gameObject.transform.parent.name);

        for(int i = 0; i < ObjectsToStore.Length; i++)
        {

            if(ObjectsToStore[i] != null)
            {

                if(ObjectsToStore[i].name == col.gameObject.transform.parent.name)
                {

                    itemsStored++;
                    Destroy(col.gameObject.transform.parent.gameObject);

                }

            }

        }

        if(itemsStored >= ObjectsToStore.Length)
        {

            GameObject.FindGameObjectWithTag("Player").transform.position += Vector3.up * 10;
            TaskManager.main.journalObject.transform.position += Vector3.up * 10;
            TaskManager.main.UpdateTasks(TaskName);

        }

    }

}
