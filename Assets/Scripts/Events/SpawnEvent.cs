using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEvent : Event
{
    void OnEnable()
    {
        ParameterIdentity = new List<(string name, System.Type type)>()
        {
            ("X", typeof(float)),
            ("Y", typeof(float)),
            ("Z", typeof(float)),
            ("Object", typeof(GameObject))
        };
    }
    public override void Trigger(params object[] parameters)
    {
        if (ParameterObjects[0])
        {
            GameObject prefab = (GameObject)ParameterObjects[0];
            Vector3 position = new Vector3(
                float.Parse(ParameterValues[0]),
                float.Parse(ParameterValues[1]),
                float.Parse(ParameterValues[2])
            );

            Instantiate(prefab, position, Quaternion.identity);
        } 
    }
}
