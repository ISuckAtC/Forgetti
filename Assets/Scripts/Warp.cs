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
    protected int cycleIndex;
    protected MeshRenderer mr;
    void Start()
    {
        if (Player == null) Player = GameObject.Find("KevsPlayer").transform;
        mr = GetComponent<MeshRenderer>();
    }

    public virtual void FireWarp(ref bool _cycled)
    {
        mr.material.color = ColorCycle[cycleIndex++];
    }

    void FixedUpdate()
    {
        //Debug.Log(transform.position + " | " + Player.position);
        if (Vector3.Distance(transform.position, Player.position) < MinDistance)
        {
            Vector3 angleToPlayer = (transform.position - Player.position).normalized;
            Vector3 vAngleDelta = Player.forward - angleToPlayer;
            if (vAngleDelta.magnitude > MinAngleDelta || vAngleDelta.magnitude < -MinAngleDelta)
            {
                if (!cycled)
                {
                    FireWarp(ref cycled);
                    if (cycleIndex == ColorCycle.Length) cycleIndex = 0;
                }
            }
            else cycled = false;
        }
    }
}
