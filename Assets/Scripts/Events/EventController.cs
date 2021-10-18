using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public List<Trigger> Triggers;
    static public EventController Main;

    public void OnValidate()
    {
        Main = this;
    }
}
