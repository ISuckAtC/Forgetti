using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBegin : MonoBehaviour
{
    public GameObject FirstDialogue;
    public GameObject Board;
    public float ActivateDistance;
    private GameObject player;
    void Start()
    {
        player = BasicController.Player;
    }

    public void Activate()
    {
        GameObject o = Instantiate(FirstDialogue, Vector3.zero, Quaternion.identity);
        o.transform.parent = Board.transform;
        Board.transform.localScale = new Vector3(2f,0.5f,0.00999999978f);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < ActivateDistance)
        {
            Activate();
        }
    }
}
