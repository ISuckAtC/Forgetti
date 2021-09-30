using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftAndTP : CraftingIngredient
{
    public override void Craft(Collision c)
    {
        GameObject g = Instantiate(Reactions[ReactiveIngredients.IndexOf(c.transform.name)], c.contacts[0].point, Quaternion.Euler(c.contacts[0].normal));
        g.GetComponent<Rigidbody>().velocity += new Vector3(0, ReactionForce, 0);
        Destroy(c.gameObject);
        Destroy(gameObject);
        BasicController.Player.transform.Translate(new Vector3(0, 10, 0), Space.World);
        g.transform.Translate(new Vector3(0, 10, 0), Space.World);
    }
}
