using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalController : MonoBehaviour
{

    public Color FinishedTaskColour;
    public GameObject[] TaskTexts;
    public TextMeshPro texto;

    private void start()
    {

        texto.color = FinishedTaskColour;

    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.J))
            texto.color = FinishedTaskColour;

    }

    public void UpdateJournal(bool taskStatus, int taskIndex)
    {

        if(taskStatus)
        {

            TaskTexts[taskIndex].GetComponent<TextMesh>().color = FinishedTaskColour;

        }

    }

}