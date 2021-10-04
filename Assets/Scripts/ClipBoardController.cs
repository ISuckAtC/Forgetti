using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClipBoardController : MonoBehaviour
{
    
    public static ClipBoardController ClipBoardCtrl;
    public Dictionary<string, GameObject> TaskTextDir;
    public GameObject[] TaskTexts;
    public GameObject ClipBoardObj, TempMenu, TempJournal;
    public PlayerMovementController PlayerMovemenet;
    public CameraController CamController;
    private bool menuActive;
    private LayerMask playerMask;

    void Start()
    {

        playerMask = ~(LayerMask.NameToLayer("Player") << 1);
        menuActive = false;
        ClipBoardCtrl = this;

        foreach (GameObject go in TaskTexts)
        {

            TaskTextDir.Add(go.name, go);
            
        }
        
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            
            ToggleMenu(false);

        }
        
        if(menuActive && Input.GetKeyDown(KeyCode.Mouse0))
        {

            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 5, playerMask, QueryTriggerInteraction.Ignore))
            {

                switch (hit.collider.name)
                {
                    
                    case "Resume":
                    menuActive = false;
                    UpdateClipBoard();
                    break;

                    case "Journal":
                    OpenJournal();
                    break;

                    case "Menu":
                    OpenMenu();
                    break;

                    case "Restart":
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    break;

                    case "Quit":
                    Application.Quit();
                    break;
                    
                }

            }
            
        }

    }

    public void ToggleMenu(bool forceOn)
    {

        if(!forceOn)
        {

            menuActive = !menuActive;

        }
        else
        {

            menuActive = true;

        }

        UpdateClipBoard();

    }

    public void OpenJournal()
    {

        TempMenu.SetActive(false);
        TempJournal.SetActive(true);

    }

    public void OpenMenu()
    {

        TempMenu.SetActive(true);
        TempJournal.SetActive(false);

    }

    public void UpdateJournal(string TaskName)
    {

        if(TaskTextDir.ContainsKey(TaskName))
        {

            TaskTextDir.TryGetValue(TaskName, out GameObject tempGO);
            Destroy(tempGO);

        }

    }

    private void UpdateClipBoard()
    {

        if(menuActive)
        {

            Cursor.lockState = CursorLockMode.None;
            Camera.main.transform.LookAt(ClipBoardObj.transform, Vector3.up);

        }
        else
        {

            Cursor.lockState = CursorLockMode.Locked;

        }

        ClipBoardObj.SetActive(menuActive);
        PlayerMovemenet.enabled = !menuActive;
        CamController.enabled = !menuActive;

    }

}