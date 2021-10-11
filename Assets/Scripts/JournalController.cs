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

    private void start()
    {

    }

    private void Update()
    {

        

    }

    public void UpdateJournal(bool taskStatus, int taskIndex)
    {

        if(taskStatus)
        {

            TaskTexts[taskIndex].GetComponent<TextMeshPro>().color = FinishedTaskColour;

        }

    }

}