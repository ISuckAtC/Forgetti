using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "ScriptableObjects/Event", order = 1)]
public class Event : ScriptableObject
{
    public virtual void Trigger(params object[] list)
    {
        Debug.Log("Event was triggered, the message from trigger is: " + (string)list[0]);
    }
}
