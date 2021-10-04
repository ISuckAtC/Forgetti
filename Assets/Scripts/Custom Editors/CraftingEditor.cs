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

        EditorGUILayout.FloatField("Reaction Force", script.ReactionForce);
        EditorGUILayout.FloatField("Crafting Delay", script.CraftingDelay);

        GUIStyle style = new GUIStyle();
        style.fontStyle = FontStyle.Bold;

        EditorGUILayout.Space(20);

        EditorGUILayout.LabelField("Reactions", style);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Add"))
        {
            script.ReactionIngredients.Add("");
            script.ReactionResults.Add(null);
        }
        if (GUILayout.Button("Remove"))
        {
            int index = script.ReactionIngredients.Count - 1;
            script.ReactionIngredients.RemoveAt(index);
            script.ReactionResults.RemoveAt(index);
        }
        GUILayout.EndHorizontal();


        for (int i = 0; i < script.ReactionIngredients.Count; ++i)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Key: ", GUILayout.Width(50));
            string key = EditorGUILayout.TextField(script.ReactionIngredients[i], GUILayout.MaxWidth(100));
            EditorGUILayout.Space(20, false);
            EditorGUILayout.LabelField("Value: ", GUILayout.Width(50));
            GameObject value = (GameObject)EditorGUILayout.ObjectField(script.ReactionResults[i], typeof(GameObject), true, GUILayout.Width(100));
            EditorGUILayout.EndHorizontal();

            script.ReactionIngredients[i] = key;
            script.ReactionResults[i] = value;
        }

        EditorUtility.SetDirty(script);
        if (!SceneManager.GetActiveScene().isDirty) EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
    }
}
