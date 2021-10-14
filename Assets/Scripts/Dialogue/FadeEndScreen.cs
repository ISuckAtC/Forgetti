using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeEndScreen : MonoBehaviour
{

    public Image img;
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
        StartCoroutine(FadeToBlack());
    }

    public IEnumerator FadeToBlack()
    {

        Color objectColorA, objectColorB;

        objectColorA = img.color;
        objectColorB = txt.color;

        while (objectColorA.a < 1)
        {
            
            objectColorA = new Color(objectColorA.r, objectColorA.g, objectColorA.b, objectColorA.a + Time.deltaTime);
            objectColorB = new Color(objectColorB.r, objectColorB.g, objectColorB.b, objectColorB.a + Time.deltaTime);
            img.color = objectColorA;
            img.color = objectColorB;

        }

        yield return null;

    }
   
}
