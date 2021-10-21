using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCompleteTrigger : Trigger
{
    void OnEnable()
    {
        ParameterIdentity = new List<(string, System.Type)>()
        {
            ("Task Name", typeof(string))
        };
    }


    public void Awake()
    {
        callbackScript = GameObject.Find("SceneController").AddComponent<TriggerCallback>();
        callbackScript.onTaskCompleteCall = TriggerEvents;
    }

    public override void TriggerEvents(params object[] parameters)
    {
        if ((string)parameters[0] == (string)ParameterValues[0]) foreach(Event e in Events) e.Trigger();
    }
}
