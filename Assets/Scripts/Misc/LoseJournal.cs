using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseJournal : MonoBehaviour
{

    public bool OnTrigger;

    private void start()
    {

        if(!OnTrigger)
        {

            JournalController.main.LoseJournal();
            Destroy(gameObject, 0.5f);

        } 

    }

    private void OnTriggerEnter(Collider col)
    {

        if(OnTrigger)
        {

            JournalController.main.LoseJournal();
            Destroy(gameObject, 0.5f);

        }

    }

}
