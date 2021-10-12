using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPup : MonoBehaviour
{

    void Start()
    {

        GameObject.FindGameObjectWithTag("Player").transform.position += Vector3.up * 10;
        TaskManager.main.journalObject.transform.position += Vector3.up * 10;
        JournalController.main.JournalWarp();
        Destroy(gameObject, 2);
        
    }

}
