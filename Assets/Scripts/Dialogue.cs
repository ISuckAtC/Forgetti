using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public float ViewRange;
    public float CloseUpDistance;
    private Transform player;
    private Transform board;
    private bool active;
    private GameObject Text;
    private TextMeshPro textMesh;
    [TextArea]
    public string DialogueText;
    public int PreDelay;
    public int CharacterDelay;
    public GameObject ChainDialogue;
    private int currentDelay;
    private int index = -1;
    private char[] dialogueArray;
    private bool writing;
    [HideInInspector] public bool Chained;

    void Awake()
    {

    }

    void Start()
    {
        player = BasicController.Player.transform;
        board = transform.parent;
        Text = board.GetChild(0).gameObject;
        textMesh = Text.GetComponent<TextMeshPro>();
        if (!Chained)
        {
            Text.GetComponent<MeshRenderer>().enabled = false;
            board.GetComponent<MeshRenderer>().enabled = false;
        }
        active = false;
        writing = false;
        dialogueArray = DialogueText.ToCharArray();
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
                textMesh.text = "";
            }
        }
        if (writing && ++currentDelay > CharacterDelay)
        {
            textMesh.text += dialogueArray[index++];
            currentDelay = 0;

            if (index == dialogueArray.Length)
            {
                writing = false;
                if (ChainDialogue) 
                {
                    GameObject chainDialogue = Instantiate(ChainDialogue, transform.position, transform.rotation);
                    chainDialogue.transform.parent = board;
                    chainDialogue.GetComponent<Dialogue>().Chained = true;
                }
            }
        }


        float distance = Vector3.Distance(player.position, board.parent.position);
        if (active)
        {
            Vector3 direction = (player.position - board.parent.position).normalized;

            board.position = board.parent.position + (direction * (distance - CloseUpDistance));
            board.forward = direction;

            if (distance > ViewRange)
            {
                Text.GetComponent<MeshRenderer>().enabled = false;
                board.GetComponent<MeshRenderer>().enabled = false;
                active = false;
            }
        }
        else
        {
            if (distance < ViewRange)
            {
                Vector3 direction = (player.position - board.parent.position).normalized;

                board.position = board.parent.position + (direction * (distance - CloseUpDistance));
                board.forward = direction;

                Text.GetComponent<MeshRenderer>().enabled = true;
                board.GetComponent<MeshRenderer>().enabled = true;
                active = true;
            }
        }
    }
}
