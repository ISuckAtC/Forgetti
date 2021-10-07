using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutInContainer : MonoBehaviour
{

    public GameObject[] ObjectsToStore;
    private int itemsStored;

    private void OnTriggerEnter(Collider col)
    {

        Debug.Log("hit " + col.gameObject.name);

        for(int i = 0; i < ObjectsToStore.Length; i++)
        {

            if(ObjectsToStore[i] == col.gameObject.transform.parent)
            {

                itemsStored++;
                Destroy(col.gameObject.transform.parent);

            }

        }

        if(itemsStored >= ObjectsToStore.Length)
        {

            GameObject.FindGameObjectWithTag("Player").transform.position += Vector3.up;

        }

    }

}
