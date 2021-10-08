using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConfusionItem
{
    
    abstract void CheckEligible();
    abstract void Confuse();
}
