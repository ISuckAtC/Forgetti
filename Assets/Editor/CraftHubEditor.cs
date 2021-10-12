using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CraftHub))]
public class CraftHubEditor : CraftingEditor
{
    public override void OnInspectorGUI()
    {
        Name = "Craft Hub Editor";

        CraftHub script = (CraftHub)target;

        

        base.OnInspectorGUI();

        EditorGUILayout.ObjectField(script.Crafting, typeof(GameObject), true, GUILayout.Width(100));
    }
}
