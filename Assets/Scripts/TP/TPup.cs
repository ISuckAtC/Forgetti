using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPup : MonoBehaviour
{

    public bool warpJournal = true;

    void Start()
    {

        TaskManager.main.TeleportUp(warpJournal);
        Destroy(gameObject, 2);
        
    }

}