using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BookshelfCrafting : CraftingIngredient
{
    public static int BookPosition;

    public override IEnumerator Craft(Collision c, Transform other, float delay = 0)
    {
        GameObject otherObject = other.gameObject;
        yield return new WaitForSeconds(delay);
        BasicController.Player.transform.Translate(new Vector3(0, 10, 0), Space.World);

        GameControl.CurrentFloor++;

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Pickup").Where(x => x.name == otherObject.name).ToArray();

        TaskManager.main.UpdateTasks(Reactions[otherObject.name].task);

        foreach (GameObject o in objects)
        {
            o.GetComponent<Collider>().enabled = false;
            o.GetComponent<Rigidbody>().isKinematic = true;
            o.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 0.05f + (0.65f * BookPosition), transform.localPosition.z);
        }
        BookPosition++;
    }
}
