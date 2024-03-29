﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    //public Text finalScoreText;
    public Text gameOverTxt;
    public GameObject gameOverMenu;
    public GameObject leaderboards;


    // Use this for initialization
    void Start()
    {
        leaderboards.SetActive(false);
        gameOverMenu.SetActive(false);
        gameOverTxt.text = "";
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        gameOverMenu.SetActive(true);


        if (collision.tag == "Player")
        {
            gameOverTxt.text = "Game Over!";
            //Application.LoadLevel("Menu");
        }
    }
}
