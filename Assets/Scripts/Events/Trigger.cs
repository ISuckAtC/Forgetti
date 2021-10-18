using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Trigger", menuName = "ScriptableObjects/Trigger", order = 1)]
public class Trigger : ScriptableObject
{
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

    public virtual void TriggerEvents()
    {
        foreach (Event ev in Events) ev.Trigger();
    }
}
