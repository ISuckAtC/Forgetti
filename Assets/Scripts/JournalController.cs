using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalController : MonoBehaviour
{

    [TextArea]
    public string HowToUse;
    public Color FinishedTaskColour;
    public GameObject[] TaskTexts;

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