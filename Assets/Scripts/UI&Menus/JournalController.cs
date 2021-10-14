using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalController : MonoBehaviour
{

    public static JournalController main;
    [TextArea]
    public string HowToUse;
    public Color FinishedTaskColour, Unfinished;
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

    public void UnlockTask(int taskIndex) => TaskTexts[taskIndex].SetActive(true);

    public void LockTask(int taskIndex) => TaskTexts[taskIndex].SetActive(false);

}