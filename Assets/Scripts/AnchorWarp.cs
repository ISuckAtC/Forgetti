using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorWarp : MonoBehaviour, IConfusionItem
{
    public float MinDistance;
    public float MinAngleDelta;
    public Transform self {get {return transform;}}
    public void Confuse()
    {
        float pivotGroundDelta = 0;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 100, 0, QueryTriggerInteraction.Ignore))
        {
            pivotGroundDelta = hit.distance;
        }
        List<Transform> validTargets = GameControl.EligibleAnchors();
        int random = Random.Range(0, validTargets.Count);
        transform.position = validTargets[random].position + new Vector3(0, pivotGroundDelta, 0);
        Debug.Log("Teleported " + name + " to " + validTargets[random].name);
    }
}
