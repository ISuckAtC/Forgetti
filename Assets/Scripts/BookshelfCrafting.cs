using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BookshelfCrafting : CraftingIngredient
{
    public static int BookPosition;
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
            o.GetComponent<Collider>().enabled = false;
            o.GetComponent<Rigidbody>().isKinematic = true;
            o.transform.localPosition = new Vector3(transform.position.x, transform.position.y + 0.05f + (0.65f * BookPosition), transform.position.z);
        }
        BookPosition++;
    }
}
