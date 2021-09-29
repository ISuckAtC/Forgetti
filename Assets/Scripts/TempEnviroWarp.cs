using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnviroWarp : MonoBehaviour
{

    public Transform PlayerTrans;
    public bool Up = true;

    private void OnTriggerEnter(Collider col)
    {

        if(col.tag == "Player")
            PlayerTrans.position = PlayerTrans.position + (Vector3.up * (Up ? 10 : -10));

    }

}
