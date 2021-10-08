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

        for(int i = 0; i < TaskNames.Length; i++)
        {

            TaskDictionary.Add(TaskNames[i], (journal.TaskTexts[i], i));

        }

    }

    public void UpdateTasks(string TaskName)
    {

        TaskStatus[TaskDictionary[TaskName].TaskStatusIndex] = true;

        journal.UpdateJournal(TaskStatus[TaskDictionary[TaskName].TaskStatusIndex], TaskDictionary[TaskName].TaskStatusIndex);

    }

}
