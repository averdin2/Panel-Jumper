﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBtnManager : MonoBehaviour {

    public string newGameLevel;
    public string mainMenu;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReplayGameBtn("Main_Game");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            MainMenuBtn("Main_Menu");
        }
    }

    public void ReplayGameBtn(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void MainMenuBtn(string mainMenu)
    {
        SceneManager.LoadScene(mainMenu);
    }
}
