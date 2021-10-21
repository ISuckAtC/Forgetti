using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(EventController))]
public class EventControllerEditor : Editor
{
    private string triggerType;
    private bool addTrigger;
    private int del = -1;
    public override void OnInspectorGUI()
    {
        EventController eventController = (EventController)target;

        List<Trigger> triggers;

        if (eventController.Triggers == null) triggers = new List<Trigger>();
        else triggers = eventController.Triggers;

        for (int i = 0; i < triggers.Count; ++i)
        {
            int delEvent = -1;
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            del = GUILayout.Button("X", GUILayout.Width(20)) ? i : del;
            Trigger trigger = (Trigger)EditorGUILayout.ObjectField(eventController.Triggers[i], typeof(Trigger), true, GUILayout.Width(100));
            GUILayout.EndHorizontal();

            if (trigger != null)
            {
                List<(string name, System.Type type)> parameterIdentity;
                List<string> parameterValues;
                List<Object> parameterObjects;

                if (trigger.ParameterIdentity == null) parameterIdentity = new List<(string, System.Type)>();
                else parameterIdentity = trigger.ParameterIdentity;

                if (trigger.ParameterValues == null) parameterValues = new List<string>();
                else parameterValues = trigger.ParameterValues;

                if (trigger.ParameterObjects == null) parameterObjects = new List<Object>();
                else parameterObjects = trigger.ParameterObjects;

                int valueCount = parameterValues.Count;

                for (int k = 0; k < parameterIdentity.Count; ++k)
                {
                    System.Type type = parameterIdentity[k].type;
                    string name = parameterIdentity[k].name;

                    EditorGUILayout.BeginHorizontal();

                    EditorGUILayout.LabelField(name + ": ", GUILayout.Width(90));

                    (string, Object) parameter = ("", null);

                    bool isObject = false;

                    switch (type.ToString())
                    {
                        case "System.Boolean":
                            if (parameterValues.Count < k + 1) parameterValues.Add("false");
                            parameter.Item1 = EditorGUILayout.Toggle(bool.Parse(parameterValues[k]), GUILayout.Width(100)).ToString();
                            break;

                        case "System.Int32":
                            if (parameterValues.Count < k + 1) parameterValues.Add("0");
                            parameter.Item1 = EditorGUILayout.IntField(int.Parse(parameterValues[k]), GUILayout.Width(100)).ToString();
                            break;

                        case "System.Single":
                            if (parameterValues.Count < k + 1) parameterValues.Add("0");
                            parameter.Item1 = EditorGUILayout.FloatField(float.Parse(parameterValues[k]), GUILayout.Width(100)).ToString();
                            break;

                        case "System.String":
                            if (parameterValues.Count < k + 1) parameterValues.Add("");
                            parameter.Item1 = EditorGUILayout.TextField(parameterValues[k], GUILayout.Width(100));
                            break;

                        default:
                            if (parameterObjects.Count < (k + 1) - parameterValues.Count) parameterObjects.Add(null);
                            parameter.Item2 = EditorGUILayout.ObjectField(parameterObjects[k - parameterValues.Count], type, true, GUILayout.Width(100));
                            isObject = true;
                            break;
                    }

                    EditorGUILayout.EndHorizontal();

                    if (isObject) parameterObjects[k - parameterValues.Count] = parameter.Item2;
                    else parameterValues[k] = parameter.Item1;
                }

                trigger.ParameterIdentity = parameterIdentity;
                trigger.ParameterValues = parameterValues;

                GUILayout.EndVertical();
                GUILayout.Space(10);
                GUILayout.BeginVertical();

                List<Event> events;
                if (trigger.Events == null) events = new List<Event>();
                else events = trigger.Events;

                for (int k = 0; k < events.Count; ++k)
                {
                    GUILayout.BeginHorizontal();
                    delEvent = GUILayout.Button("X", GUILayout.Width(20)) ? k : delEvent;

                    Event parameter = (Event)EditorGUILayout.ObjectField(trigger.Events[k], typeof(Event), true, GUILayout.Width(100));

                    GUILayout.EndHorizontal();

                    trigger.Events[k] = parameter;
                }

                if (GUILayout.Button("Add Event"))
                {
                    events.Add(null);
                }

                if (delEvent > -1)
                {
                    Event e = events[delEvent];
                    events.RemoveAt(delEvent);
                    DestroyImmediate(e);
                    delEvent = -1;
                }

                trigger.Events = events;

                foreach (Event e in trigger.Events) if (e) EditorUtility.SetDirty(e); 
            }
            GUILayout.EndVertical();

            GUILayout.EndHorizontal();


            eventController.Triggers[i] = trigger;

            EditorUtility.SetDirty(eventController.Triggers[i]);
        }

        

        GUILayout.Space(50);
        
        if (GUILayout.Button("Add Trigger"))
        {
            GenericMenu menu = new GenericMenu();

            menu.AddItem(new GUIContent("Empty Trigger"), false, OnTriggerSelected, "EmptyTrigger");
            menu.AddItem(new GUIContent("Click Trigger"), false, OnTriggerSelected, "ClickTrigger");
            menu.AddItem(new GUIContent("Trigger Trigger"), false, OnTriggerSelected, "TriggerTrigger");
            menu.AddItem(new GUIContent("Task Trigger"), false, OnTriggerSelected, "TaskTrigger");

            menu.ShowAsContext();
        }

        if (addTrigger)
        {
            Trigger trigger;
            switch(triggerType)
            {
                case "ClickTrigger":
                    trigger = (ClickTrigger)CreateInstance("ClickTrigger");
                    break;
                case "TriggerTrigger":
                    trigger = (TriggerTrigger)CreateInstance("TriggerTrigger");
                    break;
                case "TaskTrigger":
                    trigger = (TaskCompleteTrigger)CreateInstance("TaskCompleteTrigger");
                    break;
                default:
                    trigger = (Trigger)CreateInstance("Trigger");
                    break;
            } 
            trigger.Events = new List<Event>();
            //trigger.Parameters = new Dictionary<string, object>();
            triggers.Add(trigger);
            addTrigger = false;
        }

        if (del > -1)
        {
            Trigger t = triggers[del];
            triggers.RemoveAt(del);
            DestroyImmediate(t);
            del = -1;
        }

        eventController.Triggers = triggers;

        EditorUtility.SetDirty(eventController);
        if (!SceneManager.GetActiveScene().isDirty) EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
    }

    void OnTriggerSelected(object trigger)
    {
        triggerType = (string)trigger;
        addTrigger = true;
    }
}
