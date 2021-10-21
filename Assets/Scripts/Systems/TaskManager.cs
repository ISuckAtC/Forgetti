using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager main;
    public Dictionary<string, (GameObject TaskTextObj, int TaskStatusIndex, GameObject TaskParent)> TaskDictionary;
    public JournalController journal;
    public GameObject journalObject;
    public GameObject[] TaskParents;
    private string[] TaskNames;
    private bool[] TaskStatus;

    private void Start()
    {
        main = this;

        TaskDictionary = new Dictionary<string, (GameObject TaskTextObj, int TaskStatusIndex, GameObject TaskParent)>();

        TaskNames = new string[journal.TaskTexts.Length];
        TaskStatus = new bool[journal.TaskTexts.Length];

        for(int i = 0; i < TaskNames.Length; i++)
        {

            TaskNames[i] = journal.TaskTexts[i].name;
            Debug.Log("Ran: " + i + " times... TaskName: (" + TaskNames[i] + ") Text obj: " + journal.TaskTexts[i] + " Status index: " + i + " TaskParent: " + TaskParents[i].name);
            TaskDictionary.Add(TaskNames[i], (journal.TaskTexts[i], i, TaskParents[i]));

        }

    }

    public void TeleportUp(bool warpJournal)
    {

        GameObject.FindGameObjectWithTag("Player").transform.position += Vector3.up * 10;
        journalObject.transform.position += Vector3.up * 10;
        if(warpJournal)
            journal.JournalWarp();
        GameControl.CurrentFloor++;

    }

    public void CompleteTask(string taskName)
    {

        Debug.Log("Using key: " + taskName);
        if(TaskDictionary.ContainsKey(taskName))
        {

            TaskStatus[TaskDictionary[taskName].TaskStatusIndex] = true;
            journal.UpdateJournal(TaskStatus[TaskDictionary[taskName].TaskStatusIndex], TaskDictionary[taskName].TaskStatusIndex);
            if(journal.TaskTexts[TaskDictionary[taskName].TaskStatusIndex + 1])
            {

                TaskParents[TaskDictionary[taskName].TaskStatusIndex + 1].SetActive(true);
                
            }


            SendMessage("OnTaskComplete", taskName);
        }

    }

    public void UndoTask(string taskName)
    {

        Debug.Log("Using key: " + taskName);
        if(TaskDictionary.ContainsKey(taskName))
        {

            TaskStatus[TaskDictionary[taskName].TaskStatusIndex] = false;
            journal.UpdateJournal(TaskStatus[TaskDictionary[taskName].TaskStatusIndex], TaskDictionary[taskName].TaskStatusIndex);

        }

    }

    public void UnlockTask(string taskName)
    {

        if(TaskDictionary.ContainsKey(taskName))
        {

            journal.UnlockTask(TaskDictionary[taskName].TaskStatusIndex);
            TaskDictionary[taskName].TaskParent.SetActive(true);

        }

    }

    public void LockTask(string taskName)
    {

        if(TaskDictionary.ContainsKey(taskName))
        {

            journal.LockTask(TaskDictionary[taskName].TaskStatusIndex);
            TaskDictionary[taskName].TaskParent.SetActive(false);

        }

    }

}
