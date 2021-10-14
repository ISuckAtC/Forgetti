using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPThisAndPlayer : MonoBehaviour
{

    public bool warpJournal = true;

    private void Start()
    {

        TaskManager.main.TeleportUp(warpJournal);
        transform.position += Vector3.up * 10;

    }

}
