using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftHub : CraftingIngredient
{
    public GameObject Crafting;
    public override IEnumerator Craft(Collision c, Transform other, float delay = 0)
    {
        Crafting = other.gameObject;
        Debug.Log("Starting craft with " + Crafting.name);
        GameObject prefab = Reactions[Crafting.name].reaction;
        Vector3 position;
        Quaternion rotation;
        Transform parent = null;
        bool held = false;

        if (BasicController.Player.GetComponent<BasicController>().HeldObject == Crafting)
        {
            held = true;
            GameObject obj = BasicController.Player.GetComponent<BasicController>().HeldObject;
            position = obj.transform.position;
            rotation = obj.transform.rotation;
            parent = obj.transform.parent;
        }
        else
        {
            position = c.GetContact(0).point;
            rotation = Quaternion.Euler(c.GetContact(0).normal);
        }

        yield return new WaitForSeconds(delay);
        GameObject g = null;
        if (prefab) g = Instantiate(prefab, position, rotation);
        //if (g) g.transform.parent = transform;
        
        if (g) 
        {
            Rigidbody body;
            if (g.TryGetComponent<Rigidbody>(out body))
            {
                body.velocity += new Vector3(0, ReactionForce, 0);
            }
        }

        if (held) 
        {
            //if (g) BasicController.Player.GetComponent<BasicController>().HeldObject = g;
            BasicController.Player.GetComponent<BasicController>().HeldObject = null;
        }

        TaskManager.main.UpdateTasks(Reactions[Crafting.name].task);
        Debug.Log("Destroying " + Crafting.name);
        Destroy(Crafting);
    }
}
