using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CraftAndTP))]
public class CraftAndTPEditor : CraftingEditor
{
    public override void OnInspectorGUI()
    {
        Name = "Craft and TP Editor";

        CraftAndTP script = (CraftAndTP)target;

        base.OnInspectorGUI();

    }
}
