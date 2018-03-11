using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsBtnManager : MonoBehaviour {

    public string mainMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MainMenuBtn("Main_Menu");
        }
    }

    public void MainMenuBtn(string mainMenu)
    {
        SceneManager.LoadScene(mainMenu);
    }
}
