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

        if (BasicController.Player.GetComponent<BasicController>().HeldObject)
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
        GameObject g = Instantiate(prefab, position, rotation);
        if (held) g.transform.parent = parent;
        
        g.GetComponent<Rigidbody>().velocity += new Vector3(0, ReactionForce, 0);

        if (held) BasicController.Player.GetComponent<BasicController>().HeldObject = g;

        ClipBoardController.ClipBoardCtrl.UpdateJournal(Reactions[c.transform.name].task);

        Destroy(c.gameObject);
        BasicController.Player.transform.Translate(new Vector3(0, 10, 0), Space.World);
        g.transform.Translate(new Vector3(0, 10, 0), Space.World);
    }
}
