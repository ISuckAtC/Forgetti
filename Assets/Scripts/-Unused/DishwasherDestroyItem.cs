using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishwasherDestroyItem : MonoBehaviour
{
    public GameObject Plate1, Plate2, Mug1, Mug2, Spoon1, Spoon2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Resgistred");
        if (other.gameObject.CompareTag("Pickup"))
        {
            Destroy(GameObject.FindWithTag("Pickup"));
            Debug.Log("DestroyedItem");
        }
    }

}
