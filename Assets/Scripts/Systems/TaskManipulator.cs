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
    public bool UseTrigger;
    public string[] TaskNames;
    private TaskManager tm;

    private void Start()
    {

        if(!UseTrigger)
        {

            tm = TaskManager.main;
            switch (TaskMode)
            {
                
                case taskChangeMode.FinishTask:
                for(int i = 0; i < TaskNames.Length; i++) tm.CompleteTask(TaskNames[i]);
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

            Destroy(gameObject, 0.5f);
        
        }

    }

    private void OnTriggerEnter(Collider col)
    {

        if(col.gameObject.tag == "Player")
        {

            tm = TaskManager.main;
            switch (TaskMode)
            {
                
                case taskChangeMode.FinishTask:
                for(int i = 0; i < TaskNames.Length; i++) tm.CompleteTask(TaskNames[i]);
                break;

                case taskChangeMode.UndoTask:
                for(int i = 0; i < TaskNames.Length; i++) tm.UndoTask(TaskNames[i]);
                break;

                case taskChangeMode.UnlockTask:
                for(int i = 0; i < TaskNames.Length; i++) tm.UnlockTask(TaskNames[i]);
                break;

                case taskChangeMode.LockTask:
                for(int i = 0; i < TaskNames.Length; i++) 
                tm.LockTask(TaskNames[i]);
                break;

            }

            Destroy(gameObject, 0.5f);

        }

    }

}
