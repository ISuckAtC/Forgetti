using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    public bool UseSceneID;
    public int SceneID;
    
    void Start()
    {

        if(UseSceneID)
            SceneManager.LoadScene(SceneID);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

}
