using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CraftingIngredient : MonoBehaviour
{
    public Dictionary<string, (GameObject reaction, string task, bool parent)> Reactions;
    [SerializeField]public List<string> ReactionIngredients;
    public List<GameObject> ReactionResults;
    public List<string> ReactionTask;
    public List<bool> ParentResult;
    public float ReactionForce;
    public float CraftingDelay;
    private List<GameObject> hitObjects;

    public void Start()
    {
        hitObjects = new List<GameObject>();
        Reactions = new Dictionary<string, (GameObject reaction, string task, bool parent)>();
        for (int i = 0; i < ReactionIngredients.Count; ++i)
        {
            Reactions.Add(ReactionIngredients[i], (ReactionResults[i], ReactionTask[i], ParentResult[i]));
        }
    }

    public virtual IEnumerator Craft(Collision c, Transform other, float delay = 0)
    {
        GameObject otherObject = other.gameObject;
        GameObject prefab = Reactions[otherObject.name].reaction;
        Vector3 position = c.contacts[0].point;
        Quaternion rotation = Quaternion.Euler(c.contacts[0].normal);


        yield return new WaitForSeconds(delay);
        GameObject g = Instantiate(prefab, position, rotation);
        g.GetComponent<Rigidbody>().velocity += new Vector3(0, ReactionForce, 0);

        TaskManager.main.UpdateTasks(Reactions[otherObject.name].task);

        Debug.Log("Destroying " + otherObject.name);
        Destroy(otherObject);
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision c)
    {
        Transform other = c.transform;
        Debug.Log(name + " hit " + other.name);
        if (hitObjects.Contains(c.gameObject)) return;
        if (Reactions.ContainsKey(other.name))
        {
            hitObjects.Add(c.gameObject);
            Debug.Log("Crafting with " + other.name);
            Destroy(other.gameObject.GetComponent<Rigidbody>());
            other.parent = transform;
            StartCoroutine(Craft(c, other, CraftingDelay));
        }
    }
}
