using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftAndTP : CraftingIngredient
{
    public override IEnumerator Craft(Collision c, Transform other, float delay = 0)
    {
        GameObject otherObject = other.gameObject;
        GameObject prefab = Reactions[otherObject.name].reaction;
        Vector3 position = c.contacts[0].point;
        Quaternion rotation = Quaternion.Euler(c.contacts[0].normal);


        yield return new WaitForSeconds(delay);
        GameObject g = Instantiate(prefab, position, rotation);
        g.GetComponent<Rigidbody>().velocity += new Vector3(0, ReactionForce, 0);

        TaskManager.main.CompleteTask(Reactions[otherObject.name].task);

        Destroy(otherObject);
        Destroy(gameObject);
        BasicController.Player.transform.Translate(new Vector3(0, 10, 0), Space.World);
        g.transform.Translate(new Vector3(0, 10, 0), Space.World);

        GameControl.CurrentFloor++;
    }
}
