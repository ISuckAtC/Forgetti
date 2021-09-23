using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject MenuUi, Journal, MainMenu;
    private bool menuActive, journalActive;

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            
            ToggleMenuu(false);

        }

    }

    public void ToggleMenuu(bool forceOn)
    {

        if(!forceOn)
        {

            menuActive = !menuActive;

        }
        else
        {

            menuActive = true;

        }

        if(menuActive)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;

        MenuUi.SetActive(menuActive);

    }

    public void ToggleItem()
    {

        journalActive = !journalActive;

        Journal.SetActive(journalActive);
        MainMenu.SetActive(!journalActive);

    }

    public void RestartScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void QuitGame()
    {

        Application.Quit();

    }

    public void Resume()
    {

        Cursor.lockState = CursorLockMode.Locked;
        menuActive = false;
        MenuUi.SetActive(false);

    }

}
