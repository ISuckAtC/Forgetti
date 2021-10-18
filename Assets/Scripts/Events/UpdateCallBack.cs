using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCallBack : MonoBehaviour
{
    public System.Action callback = null;

    public void Update()
    {
        if (callback != null) callback.Invoke();
    }
}
