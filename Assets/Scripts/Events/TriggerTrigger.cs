using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrigger : Trigger
{
    void OnEnable()
    {
        ParameterIdentity = new List<(string, System.Type)>()
        {
            ("Trigger Enter", typeof(bool)),
            ("Trigger Exit", typeof(bool)),
            ("Trigger object", typeof(Collider))
        };
    }

    void Awake()
    {
        bool triggerEnter = bool.Parse(ParameterValues[0]);
        bool triggerExit = bool.Parse(ParameterValues[1]);
        if (ParameterObjects.Count > 0)
        {
            GameObject trigger = ((Collider)ParameterObjects[0]).gameObject;

            TriggerCallback callback = trigger.AddComponent<TriggerCallback>();
            if (triggerEnter) callback.onTriggerEnterCall = TriggerEvents;
            if (triggerExit) callback.onTriggerExitCall = TriggerEvents;
        }
    }
}
