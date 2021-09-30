using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BookshelfCrafting : CraftingIngredient
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Craft(Collision c)
    {
        BasicController.Player.transform.Translate(new Vector3(0, 10, 0), Space.World);
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Pickup").Where(x => x.name == c.transform.name).ToArray();
        foreach (GameObject o in objects)
        {
            o.transform.localPosition = new Vector3(-1.729f, 1.07f, -13.306f);
        }
    }
}
