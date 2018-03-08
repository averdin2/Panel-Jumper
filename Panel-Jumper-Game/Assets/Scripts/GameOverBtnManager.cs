using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBtnManager : MonoBehaviour {

    public string newGameLevel;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReplayGameBtn("Main_Game");
        }
    }

    public void ReplayGameBtn(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
