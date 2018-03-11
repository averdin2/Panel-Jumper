using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuBtnManager : MonoBehaviour {

    public string newGameLevel;
    public string optionsMenu;

    private void Awake()
    {
        // Setting up runtime variables
        float resAspect = 2f / 3f;
        int screenHeight = Screen.height;
        int screenWidth = (int)(screenHeight * resAspect);
        Screen.SetResolution(screenWidth, screenHeight, true);
        QualitySettings.SetQualityLevel(5);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            NewGameBtn("Main_Game");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGameBtn();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            OptionsBtn("Options_Menu");
        }

    }

    public void NewGameBtn(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }

    public void OptionsBtn(string optionsMenu)
    {
        SceneManager.LoadScene(optionsMenu);
    }
}
