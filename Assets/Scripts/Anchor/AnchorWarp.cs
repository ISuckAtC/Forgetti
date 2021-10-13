using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorWarp : MonoBehaviour, IConfusionItem
{
    public float MinDistance;
    public float MinAngleDelta;
    public Transform self {get {return transform;}}
    private Transform currentAnchor;
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
        Transform selected = validTargets[random];
        if (currentAnchor) currentAnchor.GetComponent<ObjectAnchor>().Replace(null);
        selected.GetComponent<ObjectAnchor>().Replace(transform);
        currentAnchor = selected;
        transform.position = selected.position + new Vector3(0, pivotGroundDelta, 0);
        Debug.Log("Teleported " + name + " to " + selected.name);
    }
}
