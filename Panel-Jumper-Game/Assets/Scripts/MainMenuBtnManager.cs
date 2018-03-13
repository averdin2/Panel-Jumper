using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuBtnManager : MonoBehaviour {

    public string scene;

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
            SceneChange("Main_Game");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGameBtn();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneChange("Options_Menu");
        }

    }

    public void SceneChange(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }
}
