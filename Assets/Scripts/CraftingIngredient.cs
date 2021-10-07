using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CraftingIngredient : MonoBehaviour
{
    public Dictionary<string, (GameObject reaction, string task)> Reactions;
    [SerializeField]public List<string> ReactionIngredients;
    public List<GameObject> ReactionResults;
    public List<string> ReactionTask;
    public List<string> test;
    public float ReactionForce;
    public float CraftingDelay;

    public void Start()
    {
        Reactions = new Dictionary<string, (GameObject reaction, string task)>();
        for (int i = 0; i < ReactionIngredients.Count; ++i)
        {
            Reactions.Add(ReactionIngredients[i], (ReactionResults[i], ReactionTask[i]));
        }
    }

    public virtual IEnumerator Craft(Collision c, Transform other, float delay = 0)
    {
        GameObject prefab = Reactions[c.transform.name].reaction;
        Vector3 position = c.contacts[0].point;
        Quaternion rotation = Quaternion.Euler(c.contacts[0].normal);


        yield return new WaitForSeconds(delay);
        GameObject g = Instantiate(prefab, position, rotation);
        g.GetComponent<Rigidbody>().velocity += new Vector3(0, ReactionForce, 0);

        //ClipBoardController.ClipBoardCtrl.UpdateJournal(Reactions[c.transform.name].task);

        Destroy(c.gameObject);
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision c)
    {
        Transform other = c.transform;
        Debug.Log(name + " hit " + other.name);
        if (Reactions.ContainsKey(other.name))
        {
            Debug.Log("Crafting with " + other.name);
            Destroy(other.gameObject.GetComponent<Rigidbody>());
            Destroy(other.gameObject.GetComponent<Collider>());
            other.parent = transform;
            StartCoroutine(Craft(c, other, CraftingDelay));
        }
    }
}
