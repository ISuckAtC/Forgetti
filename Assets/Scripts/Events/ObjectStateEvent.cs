using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStateEvent : Event
{
    void OnEnable()
    {
        ParameterIdentity = new List<(string name, System.Type type)>()
        {
            ("Enable", typeof(bool)),
            ("Disable", typeof(bool)),
            ("Toggle", typeof(bool)),
            ("Destroy", typeof(bool)),
            ("Object", typeof(GameObject))
        };
    }
    public override void Trigger(params object[] parameters)
    {
        if (ParameterObjects[0])
        {
            GameObject obj = (GameObject)ParameterObjects[0];
            bool enable = bool.Parse(ParameterValues[0]);
            bool disable = bool.Parse(ParameterValues[1]);
            bool toggle = bool.Parse(ParameterValues[2]);
            bool destroy = bool.Parse(ParameterValues[3]);

            if (enable) obj.SetActive(true);
            if (disable) obj.SetActive(false);
            if (toggle) obj.SetActive(!obj.activeSelf);
            if (destroy) Destroy(obj, 0);
        } 
    }
}
