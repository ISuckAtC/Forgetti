using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public Transform Player;
    public float MinDistance;
    public float MinAngleDelta;
    public Color[] ColorCycle;
    private bool cycled;
    private int cycleIndex;
    private MeshRenderer mr;
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    void FixedUpdate()
    {
        Debug.Log(transform.position + " | " + Player.position);
        if (Vector3.Distance(transform.position, Player.position) < MinDistance)
        {
            Vector3 angleToPlayer = (transform.position - Player.position).normalized;
            Vector3 vAngleDelta = Player.forward - angleToPlayer;
            if (vAngleDelta.magnitude > MinAngleDelta || vAngleDelta.magnitude < -MinAngleDelta)
            {
                if (!cycled)
                {
                    cycled = true;
                    mr.material.color = ColorCycle[cycleIndex++];
                    if (cycleIndex == ColorCycle.Length) cycleIndex = 0;
                }
            }
            else cycled = false;

        }
    }
}
