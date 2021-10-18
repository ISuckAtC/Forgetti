using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "ScriptableObjects/Event", order = 1)]
public class Event : ScriptableObject
{
    public virtual void Trigger(params object[] list)
    {
        for (int i = 0; i < (int)list[1]; ++i) Debug.Log("Event was triggered, the message from trigger is: " + (string)list[0]);
    }
}
