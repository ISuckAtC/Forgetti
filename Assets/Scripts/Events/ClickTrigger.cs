using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTrigger : Trigger
{
    private GameObject callbackObject;
    public void OnEnable()
    {
        ParameterIdentity = new List<(string, System.Type)>()
        {
            ("Click Message", typeof(string)),
            ("Click Count", typeof(int))
        };
    }
    public void OnDestroy()
    {
        DestroyImmediate(callbackObject);
    }
    public void Awake()
    {
        
        if (!callbackObject) 
        {
            callbackObject = new GameObject("TriggerCallBack");
            callbackObject.transform.parent = EventController.Main.transform;
            UpdateCallBack callback = callbackObject.AddComponent<UpdateCallBack>();
            callback.callback = CheckClick;
        }
    }

    public void CheckClick()
    {
        if (Input.GetMouseButtonDown(0)) TriggerEvents();
    }

    public override void TriggerEvents()
    {
        string message = ParameterValues[0];
        int count = int.Parse(ParameterValues[1]);
        foreach (Event ev in Events) ev.Trigger(message, count);
    }
}
