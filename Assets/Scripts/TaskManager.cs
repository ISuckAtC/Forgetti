using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{

    public static TaskManager main;
    public Dictionary<string, (GameObject TaskTextObj, int TaskStatusIndex)> TaskDictionary;
    public string[] TaskNames;
    public bool[] TaskStatus;
    public JournalController journal;

    private void Start()
    {

        main = this;

        TaskDictionary = new Dictionary<string, (GameObject TaskTextObj, int TaskStatusIndex)>();

        for(int i = 0; i < TaskNames.Length; i++)
        {

            Debug.Log("Ran: " + i + " TaskName: " + TaskNames[i] + " obj: " + journal.TaskTexts[i] + " Stat index: " + i);
            TaskDictionary.Add(TaskNames[i], (journal.TaskTexts[i], i));

        }

    }

    public void UpdateTasks(string TaskName)
    {

        //Debug.Log("Using key: " + TaskName);
        TaskStatus[TaskDictionary[TaskName].TaskStatusIndex] = true;

        journal.UpdateJournal(TaskStatus[TaskDictionary[TaskName].TaskStatusIndex], TaskDictionary[TaskName].TaskStatusIndex);

    }

}
