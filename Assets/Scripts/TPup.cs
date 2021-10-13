using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPup : MonoBehaviour
{

    void Start()
    {

        TaskManager.main.TeleportUp();
        Destroy(gameObject, 2);
        
    }

}