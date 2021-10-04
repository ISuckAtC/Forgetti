using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public float ViewRange;
    public float CloseUpDistance;
    private GameObject player;
    private bool active;
    public GameObject Text;
    private TextMeshPro textMesh;
    [TextArea]
    public string DialogueText;
    public int PreDelay;
    public int CharacterDelay;
    private int currentDelay;
    private int index = -1;
    private char[] dialogueArray;
    private bool writing;

    void Awake()
    {
        textMesh = Text.GetComponent<TextMeshPro>();
        Text.GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        active = false;
        writing = false;
        dialogueArray = DialogueText.ToCharArray();
    }

    void Start()
    {
        player = BasicController.Player;
    }

    void FixedUpdate()
    {
        if (index < 0)
        {
            if (++currentDelay > PreDelay)
            {
                index++;
                currentDelay = 0;
                writing = true;
            }
        }
        if (writing && ++currentDelay > CharacterDelay)
        {
            textMesh.text += dialogueArray[index];
            index++;
            currentDelay = 0;

            if (index == dialogueArray.Length)
            {
                writing = false;
            }
        }


        float distance = Vector3.Distance(player.transform.position, transform.parent.position);
        if (active)
        {
            Vector3 direction = (player.transform.position - transform.parent.position).normalized;

            transform.position = transform.parent.position + (direction * (distance - CloseUpDistance));
            transform.forward = direction;

            if (distance > ViewRange)
            {
                Text.GetComponent<MeshRenderer>().enabled = false;
                GetComponent<MeshRenderer>().enabled = false;
                active = false;
            }
        }
        else
        {
            if (distance < ViewRange)
            {
                Vector3 direction = (player.transform.position - transform.parent.position).normalized;

                transform.position = transform.parent.position + (direction * (distance - CloseUpDistance));
                transform.forward = direction;
                Text.GetComponent<MeshRenderer>().enabled = true;
                GetComponent<MeshRenderer>().enabled = true;
                active = true;
            }
        }
    }
}
