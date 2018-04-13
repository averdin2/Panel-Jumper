using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverBtnManager : MonoBehaviour {
    // Controls all the buttons within the Game Over menu

    public string scene;
    public GameObject leaderboards;

    Leaderboard scores;


    private void Start()
    {
        scores = GameObject.FindObjectOfType<Leaderboard>();
    }


    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneChange("Main_Game");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneChange("Main_Menu");
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ShowLeaderboards();
        }
    }

    // Called to change scene based on what value is contained in 'string'
    public void SceneChange(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ShowLeaderboards()
    {
        leaderboards.SetActive(!leaderboards.activeSelf);
    }

}
