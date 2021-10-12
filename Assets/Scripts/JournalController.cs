using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalController : MonoBehaviour
{

    [TextArea]
    public static JournalController main;
    public string HowToUse;
    public Color FinishedTaskColour;
    public GameObject[] TaskTexts;
    public Vector3 WarpPos;
    private Quaternion WarpRot;

    private void Start()
    {

        main = this;
        WarpPos = transform.position + Vector3.up * 10;
        WarpRot = transform.rotation;

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

        }

    }

    public void UnlockTask(int taskIndex) => TaskTexts[taskIndex].SetActive(true);

    public void LockTask(int taskIndex) => TaskTexts[taskIndex].SetActive(false);

}