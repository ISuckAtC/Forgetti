using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManipulator : MonoBehaviour
{

    public enum taskChangeMode
    {

        FinishTask,
        UndoTask,
        UnlockTask,
        LockTask
        
    }

    public taskChangeMode TaskMode;
    public string[] TaskNames;
    private TaskManager tm;

    private void Start()
    {

        tm = TaskManager.main;

        switch (TaskMode)
        {
            
            case taskChangeMode.FinishTask:
            for(int i = 0; i < TaskNames.Length; i++) tm.UpdateTasks(TaskNames[i]);
            break;

            case taskChangeMode.UndoTask:
            for(int i = 0; i < TaskNames.Length; i++) tm.UndoTask(TaskNames[i]);
            break;

            case taskChangeMode.UnlockTask:
            for(int i = 0; i < TaskNames.Length; i++) tm.UnlockTask(TaskNames[i]);
            break;

            case taskChangeMode.LockTask:
            for(int i = 0; i < TaskNames.Length; i++) tm.LockTask(TaskNames[i]);
            break;

        }

    }

}
