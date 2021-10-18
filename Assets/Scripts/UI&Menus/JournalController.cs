using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalController : MonoBehaviour , IInteractable
{

    public static JournalController main;
    [TextArea]
    public string HowToUse;
    public Transform JournalAnchor;
    public GameObject JournalVisuals;
    public Color FinishedTaskColour, Unfinished;
    public GameObject[] TaskTexts;
    public Vector3 WarpPos;
    private Rigidbody rb;
    private Quaternion WarpRot;
    private bool journalActive, journalOnPlayer;
    public GameObject[] Links { get; set;}

    private void Start()
    {

        main = this;
        rb = gameObject.GetComponent<Rigidbody>();
        WarpPos = transform.position + Vector3.up * 10;
        WarpRot = transform.rotation;
        Links = new GameObject[0];

    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Tab) && journalOnPlayer)
            ToggleJournal();

        if(Input.GetKeyDown(KeyCode.E) && journalOnPlayer)
            PutDownJournal();

    }

    private void PutDownJournal()
    {

        transform.parent = null;
        rb.constraints = RigidbodyConstraints.None;
        rb.detectCollisions = true;
        journalOnPlayer = false;
        JournalVisuals.SetActive(true);
        transform.position = Camera.main.transform.forward + Camera.main.transform.position;

    }

    private void ToggleJournal()
    {

        journalActive = !journalActive;
        JournalVisuals.SetActive(journalActive);

    }

    public void JournalWarp()
    {

        Vector3 tempPos = transform.position + Vector3.up * 10;
        Quaternion tempRot = transform.rotation;
        transform.position = WarpPos;
        transform.rotation = WarpRot;
        WarpPos = tempPos;
        WarpRot = tempRot;

    }

    public void UpdateJournal(bool taskStatus, int taskIndex)
    {

        if(taskStatus)
        {

            TaskTexts[taskIndex].GetComponent<TextMeshPro>().color = FinishedTaskColour;
            
            if(taskIndex + 1 < TaskTexts.Length)
            {

                TaskTexts[taskIndex + 1].SetActive(true);

            }

        }
        /*else
        {

            TaskTexts[taskIndex].GetComponent<TextMeshPro>().color = Unfinished;
            
            if(taskIndex + 1 < TaskTexts.Length)
            {

                TaskTexts[taskIndex + 1].SetActive(false);

            }

        }*/

    }

    public void Interact(bool chain = false)
    {

        transform.parent = JournalAnchor;
        transform.position = JournalAnchor.position;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.detectCollisions = false;
        transform.LookAt(Camera.main.transform, Vector3.up);
        journalOnPlayer = true;
        journalActive = false;
        ToggleJournal();

    }

    public void UnlockTask(int taskIndex) => TaskTexts[taskIndex].SetActive(true);

    public void LockTask(int taskIndex) => TaskTexts[taskIndex].SetActive(false);

}