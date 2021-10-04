using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CraftingIngredient : MonoBehaviour
{
    public Dictionary<string, GameObject> Reactions;
    [SerializeField]public List<string> ReactionIngredients;
    public List<GameObject> ReactionResults;
    public List<string> ReactionTask;
    public List<string> test;
    public float ReactionForce;
    public float CraftingDelay;

    public void Start()
    {
        Reactions = new Dictionary<string, GameObject>();
        for (int i = 0; i < ReactionIngredients.Count; ++i)
        {
            Reactions.Add(ReactionIngredients[i], ReactionResults[i]);
        }
    }

    public virtual IEnumerator Craft(Collision c, float delay = 0)
    {
        GameObject prefab = Reactions[c.transform.name];
        Vector3 position = c.contacts[0].point;
        Quaternion rotation = Quaternion.Euler(c.contacts[0].normal);


        yield return new WaitForSeconds(delay);
        GameObject g = Instantiate(prefab, position, rotation);
        g.GetComponent<Rigidbody>().velocity += new Vector3(0, ReactionForce, 0);
        Destroy(c.gameObject);
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision c)
    {
        Debug.Log(name + " hit " + c.transform.name);
        if (Reactions.ContainsKey(c.transform.name))
        {
            Destroy(c.transform.gameObject.GetComponent<Rigidbody>());
            c.transform.parent = transform;
            StartCoroutine(Craft(c, CraftingDelay));
        }
    }
}
