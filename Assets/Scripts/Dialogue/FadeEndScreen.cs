using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeEndScreen : MonoBehaviour
{
    public GameObject FadeoutScreen;
    public bool Toggle;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
                    StartCoroutine(FadeToBlack());
    }

    public IEnumerator FadeToBlack (bool FadeToBlack = true, int fadeSpeed = 1)
    {
        //yield return new WaitForEndOfFrame();

        Color objectColor;

        if (Toggle)
        {
             objectColor = FadeoutScreen.GetComponent<Image>().color;
        }
        else
        {
             objectColor = FadeoutScreen.GetComponent<Text>().color;
        }

        float fadeAmount;

        if (FadeToBlack)
        {
            while (objectColor.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);

                if(Toggle)
                {
                    FadeoutScreen.GetComponent<Image>().color = objectColor;
                }
                else
                {
                    FadeoutScreen.GetComponent<Text>().color = objectColor; 
                }
                yield return null;

                

            }
        }



    }
   
}
