using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpEvent : Event
{
    void OnEnable()
    {
        ParameterIdentity = new List<(string name, System.Type type)>()
        {
            ("Warp Object", typeof(IConfusionItem))
        };
    }
    public override void Trigger(params object[] parameters)
    {
        if (ParameterObjects[0])
        {
            IConfusionItem confuse = (IConfusionItem)ParameterObjects[0];

            confuse.Confuse();
        } 
    }
}
