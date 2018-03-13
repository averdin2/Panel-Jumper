using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsBtnManager : MonoBehaviour {
    // Controls all the buttons within the options menu

    public string scene;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneChange("Main_Menu");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            SceneChange("Main_Game");
        }
    }

    // Called to change scene based on what value is contained in 'string'
    public void SceneChange(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
