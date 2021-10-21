using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : ScriptableObject
{
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
    public virtual void Trigger(params object[] parameters)
    {
        Debug.Log("Event was triggered, the message from trigger is: " + (string)parameters[0]);
    }
}
