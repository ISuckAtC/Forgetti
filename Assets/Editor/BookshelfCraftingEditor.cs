using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BookshelfCrafting))]
public class BookshelfCraftingEditor : CraftingEditor
{
    public override void OnInspectorGUI()
    {
        Name = "Bookshelf Crafting Editor";

        BookshelfCrafting script = (BookshelfCrafting)target;

        base.OnInspectorGUI();

    }
}
