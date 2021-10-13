using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPThisAndPlayer : MonoBehaviour
{

    private void Start()
    {

        TaskManager.main.TeleportUp();
        transform.position += Vector3.up * 10;

    }

}
