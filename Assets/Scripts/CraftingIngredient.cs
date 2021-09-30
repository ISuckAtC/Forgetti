using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CraftingIngredient : MonoBehaviour
{
    public List<string> ReactiveIngredients;
    public List<GameObject> Reactions;
    public float ReactionForce;

    public virtual void Craft(Collision c)
    {
        GameObject g = Instantiate(Reactions[ReactiveIngredients.IndexOf(c.transform.name)], c.contacts[0].point, Quaternion.Euler(c.contacts[0].normal));
        g.GetComponent<Rigidbody>().velocity += new Vector3(0, ReactionForce, 0);
        Destroy(c.gameObject);
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision c)
    {
        if (ReactiveIngredients.Contains(c.transform.name))
        {
            int index = ReactiveIngredients.IndexOf(c.transform.name);
            if (index > Reactions.Count)
            {
                Debug.Log("Reaction not specified for [" + transform.name + " + " + c.transform.name + "]");
            }
            else
            {
                Craft(c);
            }
        }
    }
}
