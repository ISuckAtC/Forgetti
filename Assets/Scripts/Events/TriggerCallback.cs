using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCallback : MonoBehaviour
{
    public System.Action<object[]> updateCall = null;
    public System.Action<object[]> onTriggerEnterCall = null;
    public System.Action<object[]> onTriggerExitCall = null;
    public System.Action<object[]> onTaskCompleteCall = null;

    public void Update()
    {
        if (updateCall != null) updateCall(new object[0]);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (onTriggerEnterCall != null) onTriggerEnterCall(new object[] {other});
    }

    public void OnTriggerExit(Collider other)
    {
        if (onTriggerExitCall != null) onTriggerExitCall(new object[] {other});
    }

    public void OnTaskComplete(params object[] parameters)
    {
        if (onTaskCompleteCall != null) onTaskCompleteCall(parameters);
    }
}
