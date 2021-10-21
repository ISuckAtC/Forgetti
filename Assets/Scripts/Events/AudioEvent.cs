using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvent : Event
{
    void OnEnable()
    {
        ParameterIdentity = new List<(string name, System.Type type)>()
        {
            ("Audio Clip", typeof(AudioClip)),
            ("Audio Source", typeof(AudioSource))
        };
    }
    public override void Trigger(params object[] parameters)
    {
        if (ParameterObjects[0] && ParameterObjects[1])
        {
            AudioClip clip = (AudioClip)ParameterObjects[0];
            AudioSource source = (AudioSource)ParameterObjects[1];

            source.PlayOneShot(clip);
        } 
    }
}
