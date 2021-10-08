using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl Self;
    public List<SerializableList<Transform>> AnchorsPerFloor;
    public List<SerializableList<AnchorWarp>> ConfusionItemsPerFloor;
    public static int CurrentFloor;
    public float ConfusionRate;

    public void Awake()
    {
        Self = this;
    }

    public void Start()
    {
        InvokeRepeating(nameof(Confusion), 5, 10);
    }

    public void Confusion()
    {
        List<AnchorWarp> floorItems = ConfusionItemsPerFloor[CurrentFloor];
        List<int> checkedIndices = new List<int>();
        int eligible = 0;
        for (int i = 0; i < floorItems.Count; ++i)
        {
            eligible = Random.Range(0, floorItems.Count);
            checkedIndices.Add(eligible);
            if (CheckConfusionEligible(floorItems[eligible].self, floorItems[eligible].MinAngleDelta, floorItems[eligible].MinDistance))
            {
                floorItems[eligible].Confuse();
                return;
            }
        }
        Debug.Log("No item on the floor was eligible for confusion");
    }

    public static bool CheckConfusionEligible(Transform obj, float minAngleDelta = 1.4f, float minDistance = 10f)
    {
        if (Vector3.Distance(obj.position, BasicController.Player.transform.position) < minDistance)
        {
            Vector3 angleToPlayer = (obj.position - BasicController.Player.transform.position).normalized;
            Vector3 vAngleDelta = BasicController.Player.transform.forward - angleToPlayer;
            if (vAngleDelta.magnitude > minAngleDelta || vAngleDelta.magnitude < -minAngleDelta)
            {
                return true;
            }
        }
        return false;
    }

    public static List<Transform> EligibleAnchors()
    {
        if (Self.AnchorsPerFloor[CurrentFloor] == null || Self.AnchorsPerFloor[CurrentFloor].Count == 0)
        {
            throw new System.Exception("Anchors are empty");
        }
        List<Transform> eligibleAnchors = new List<Transform>();
        for (int i = 0; i < Self.AnchorsPerFloor[CurrentFloor].Count; ++i)
        {
            if (CheckConfusionEligible(Self.AnchorsPerFloor[CurrentFloor][i], 1.4f, 10)) eligibleAnchors.Add(Self.AnchorsPerFloor[CurrentFloor][i]);
        }
        return Self.AnchorsPerFloor[CurrentFloor] ?? null;
    }
}
