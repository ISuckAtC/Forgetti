using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{

    public float FadeSpeed;
    public Image Overlay;
    public bool Cover;
    private Color current;

    void Start()
    {
        current = Overlay.color;
    }

    void FixedUpdate()
    {
        if (Cover && current.a < 1f)
        {
            if (current.a + FadeSpeed < 1f) current.a = current.a + FadeSpeed;
            else current.a = 1f;
            Overlay.color = current;
        }
        else if (current.a > 0f)
        {
            if (current.a - FadeSpeed > 0f) current.a = current.a - FadeSpeed;
            else current.a = 0f;
            Overlay.color = current;
        }
    }

}
