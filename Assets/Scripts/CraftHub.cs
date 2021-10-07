using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftHub : CraftingIngredient
{
    public override IEnumerator Craft(Collision c, float delay = 0)
    {
        GameObject prefab = Reactions[c.transform.name].reaction;
        Vector3 position;
        Quaternion rotation;
        Transform parent = null;
        bool held = false;

        if (BasicController.Player.GetComponent<BasicController>().HeldObject == c.gameObject)
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
        if (g) g.transform.parent = transform;
        
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

        //ClipBoardController.ClipBoardCtrl.UpdateJournal(Reactions[c.transform.name].task);

        Destroy(c.gameObject);
    }
}
