using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Trigger", menuName = "ScriptableObjects/Trigger", order = 1)]
public class Trigger : ScriptableObject
{
    protected TriggerCallback callbackScript;
    [HideInInspector]
    public List<Event> Events;

    public List<(string name, System.Type type)> ParameterIdentity = new List<(string, System.Type)>()
    {
        ("hi", typeof(float))
    };
    public List<string> ParameterValues = new List<string>()
    {

    };
    public List<Object> ParameterObjects = new List<Object>()
    {

    };

    public void OnDestroy()
    {
        if (callbackScript != null) DestroyImmediate(callbackScript);
    }


    public virtual void TriggerEvents(params object[] parameters)
    {
        foreach (Event ev in Events) ev.Trigger(new object[] {"HELLO"});
    }
}
