using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform Player;
    private Transform PlayerCam;
    public float MinDistance;
    public float MinAngleDelta;
    public float FollowDistance;
    public Vector3 CollideCheckBox;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCam = Player.GetChild(0);
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, Player.position) > MinDistance)
        {
            Vector3 angleToPlayer = (transform.position - Player.position).normalized;
            Vector3 vAngleDelta = PlayerCam.forward - angleToPlayer;
            if (vAngleDelta.magnitude > MinAngleDelta || vAngleDelta.magnitude < -MinAngleDelta)
            {
                Vector3 followPosition = Player.position - (Player.forward * FollowDistance);
                if (Physics.OverlapBox(followPosition, CollideCheckBox, Player.rotation, 0, QueryTriggerInteraction.Ignore).Length == 0)
                {
                    transform.position = followPosition;
                    transform.rotation = Player.rotation;
                }
                else
                {
                    Debug.Log("Overlap test failed");
                }
            }
        }
    }
}
