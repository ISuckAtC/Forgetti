using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutInContainer : MonoBehaviour
{

    public string TaskName;
    public GameObject SpawnOnComplete;
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

            TaskManager.main.TeleportUp(true);
            TaskManager.main.UpdateTasks(TaskName);
            if(SpawnOnComplete)
                Instantiate(SpawnOnComplete, transform.position, Quaternion.identity);

        }

    }

}
