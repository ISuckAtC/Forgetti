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
    public GameObject[] Chain;
    private int currentDelay;
    private int index = -1;
    private char[] dialogueArray;
    private bool writing;
    [HideInInspector] public bool Chained;
    public bool UseSkip;
    private bool skip;
    private bool noChain;

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

    public void Skip()
    {
        if (UseSkip)
        {
            if (skip)
            {
                Next();
            }
            else
            {
                textMesh.text = "";
                for (int i = 0; i < dialogueArray.Length; ++i)
                {
                    textMesh.text += dialogueArray[i];
                }
                skip = true;
            }
        }
    }

    void Next()
    {
        writing = false;
        for (int i = 0; i < Chain.Length; ++i)
        {
            if (Chain[i])
            {
                
                GameObject chainDialogue = Instantiate(Chain[i], transform.position, transform.rotation);
                chainDialogue.transform.parent = board;
                Dialogue dialogue;
                if (chainDialogue.TryGetComponent<Dialogue>(out dialogue))
                {
                    dialogue.Chained = true;
                }
            }
            else noChain = true;
        }
        if (noChain) Destroy(gameObject.transform.parent.gameObject);
        else Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (skip) return;
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
            if (index == dialogueArray.Length)
            {
                if (UseSkip)
                {
                    skip = true;
                    return;
                }
                else Next();
            }
            else
            {
                textMesh.text += dialogueArray[index];
                index++;
                currentDelay = 0;
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
