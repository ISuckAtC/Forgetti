using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTrigger : Trigger
{
    public void OnEnable()
    {
        ParameterIdentity = new List<(string, System.Type)>()
        {
            ("Click Message", typeof(string)),
            ("Click Count", typeof(int))
        };
    }
    public void Awake()
    {
        
        if (!callbackScript) 
        {
            callbackScript = EventController.Main.gameObject.AddComponent<TriggerCallback>();
            callbackScript.updateCall = CheckClick;
        }
    }

    public void CheckClick(params object[] parameters)
    {
        if (Input.GetMouseButtonDown(0)) TriggerEvents();
    }

    public override void TriggerEvents(params object[] parameters)
    {
        string message = ParameterValues[0];
        int count = int.Parse(ParameterValues[1]);
        foreach (Event ev in Events) ev.Trigger(message, count);
    }
}
