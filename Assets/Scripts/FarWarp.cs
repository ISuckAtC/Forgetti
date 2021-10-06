using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarWarp : Warp
{
    public float MaxForce;
    public float MinForce;
    [Tooltip("The probability in percent divided by 10 that it will move, rolled 10 times per second. (Effectively % chance it will roll per second")]
    public float Probability;

    private float timer;
    public override void FireWarp(ref bool _cycled)
    {
        if (timer++ > 30)
        {
            timer = 0;
            if (Random.Range(0f, 100f) < Probability / 10f)
            {
                mr.material.color = ColorCycle[cycleIndex++];
                Vector3 direction = (new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f))).normalized;
                _cycled = true;
                GetComponent<Rigidbody>().AddForce(Random.Range(MinForce, MaxForce) * direction, ForceMode.VelocityChange);
            }
        }
    }
}
