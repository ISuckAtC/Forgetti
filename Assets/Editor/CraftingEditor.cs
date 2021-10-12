using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(CraftingIngredient))]
public class CraftingEditor : Editor
{
    protected string Name = "Crafting Ingredient Editor";
    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField(Name);
        EditorGUILayout.Space(20);

        CraftingIngredient script = (CraftingIngredient)target;

        float force = EditorGUILayout.FloatField("Reaction Force", script.ReactionForce);
        float delay = EditorGUILayout.FloatField("Crafting Delay", script.CraftingDelay);

        script.ReactionForce = force;
        script.CraftingDelay = delay;

        GUIStyle style = new GUIStyle();
        style.fontStyle = FontStyle.Bold;

        EditorGUILayout.Space(20);

        EditorGUILayout.LabelField("Reactions", style);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Add"))
        {
            if (script.ReactionIngredients == null) script.ReactionIngredients = new List<string>();
            if (script.ReactionResults == null) script.ReactionResults = new List<GameObject>();
            if (script.ReactionTask == null) script.ReactionTask = new List<string>();
            script.ReactionIngredients.Add("");
            script.ReactionResults.Add(null);
            script.ReactionTask.Add("");
        }
        if (GUILayout.Button("Remove"))
        {
            if (script.ReactionIngredients == null) script.ReactionIngredients = new List<string>();
            if (script.ReactionResults == null) script.ReactionResults = new List<GameObject>();
            if (script.ReactionTask == null) script.ReactionTask = new List<string>();
            int index = script.ReactionIngredients.Count - 1;
            script.ReactionIngredients.RemoveAt(index);
            script.ReactionResults.RemoveAt(index);
            script.ReactionTask.RemoveAt(index);
        }
        GUILayout.EndHorizontal();


        for (int i = 0; i < script.ReactionIngredients.Count; ++i)
        {
            if (script.ParentResult.Count <= i) script.ParentResult.Add(false);




            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Ingredient: ", GUILayout.Width(60));
            string key = EditorGUILayout.TextField(script.ReactionIngredients[i], GUILayout.MaxWidth(100));
            EditorGUILayout.Space(0, false);
            EditorGUILayout.LabelField("Result: ", GUILayout.Width(40));
            GameObject value = (GameObject)EditorGUILayout.ObjectField(script.ReactionResults[i], typeof(GameObject), true, GUILayout.Width(100));
            EditorGUILayout.Space(0, false);
            EditorGUILayout.LabelField("Task: ", GUILayout.Width(33));
            string task = EditorGUILayout.TextField(script.ReactionTask[i], GUILayout.MaxWidth(100));
            EditorGUILayout.Space(0, false);
            EditorGUILayout.LabelField("Parent: ", GUILayout.Width(40));
            bool parent = EditorGUILayout.Toggle(script.ParentResult[i], GUILayout.MaxWidth(20));
            EditorGUILayout.EndHorizontal();

            script.ReactionIngredients[i] = key;
            script.ReactionResults[i] = value;
            script.ReactionTask[i] = task;
            script.ParentResult[i] = parent;
        }

        EditorUtility.SetDirty(script);
        if (!SceneManager.GetActiveScene().isDirty) EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
    }
}
