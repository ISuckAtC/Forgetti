using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConfusionItem
{
    // The method call for initiating a confusion, as in, teleporting the item around
    // When teleporting remember to use a raycast to find the ground, and teleport relative to the distance between the pivot point and the ground
    abstract void Confuse();

    // Remember to set this, or it wont work, it should always get the transform
    Transform self {get;}
}
