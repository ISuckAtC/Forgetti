using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public void PlayLevel(int lvl)
    {

        SceneManager.LoadScene(lvl);

    }

}
