using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public GameObject[] Links {get; set;}
    public abstract void Interact(bool chain = false);
}
