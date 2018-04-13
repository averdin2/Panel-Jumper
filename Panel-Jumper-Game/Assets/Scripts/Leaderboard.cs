using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Leaderboard : MonoBehaviour {

    // Leaderboard that stores player inputed names and high scores in a dictionary

    public GameObject leaderboards;


    Dictionary<string, int> playerScores;

    int newScoreUpdate = 0;
    int topFive = 0;

    void Start ()
    {

        //Sets the top five scores
        for (int i = 0; i < 5; i++)
        {
            SetScore(PlayerPrefs.GetString("pname_" + i, ""), PlayerPrefs.GetInt("pscore_" + i, 0));
        }

    }

    // Initializing playerScores dictionary
    void Init()
    {
        if(playerScores != null)
        {
            return;
        }
        playerScores = new Dictionary<string, int>();
    }


    // Returns the score value given a playerName
    public int GetScore(string playerName)
    {
        Init();

        if(playerScores.ContainsKey(playerName) == false)
        {
            return 0;
        }
        return playerScores[playerName];
    }

    // Sets a new score by a new or the same player
    // Bases a new entry on whether the leaderboard threshold is reached and if the score is higher that the lowest on the list
    // A new score for a recuring player will be set to the new high score
    public void SetScore(string playerName, int newScore)
    {
        Init();

        if (playerName == "" || newScore == 0)
        {
            return;
        }

        if (playerScores.ContainsKey(playerName) == false && playerScores.Count >= 5)
        {
            string smallestScore = playerScores.Keys.OrderByDescending(name => GetScore(name)).Last();
            if(newScore > GetScore(smallestScore))
            {
                playerScores.Remove(smallestScore);
                SaveScore(playerName, newScore);
            }
            return;
        }
        else if(playerScores.ContainsKey(playerName) == true)
        {
            if(newScore > GetScore(playerName))
            {
                SaveScore(playerName, newScore);
                return;
            }
            return;
        }

        SaveScore(playerName, newScore);

        //newScoreUpdate++;
        //playerScores[playerName] = newScore;
        //PlayerPrefs.SetString("pname_" + 1, playerName);
        //PlayerPrefs.SetInt("pscore_" + 1, newScore);
    }

    public string[] GetPlayerNames()
    {
        Init();

        return playerScores.Keys.OrderByDescending(name => GetScore(name)).ToArray();
    }

    // Used to optimize updating leaderboard list
    public int GetNewScoreUpdate()
    {
        return newScoreUpdate;
    }

    void SaveScore(string name, int score)
    {
        if (topFive < 5)
        {
            
            newScoreUpdate++;
            playerScores[name] = score;
            PlayerPrefs.SetString("pname_" + topFive, name);
            PlayerPrefs.SetInt("pscore_" + topFive, score);
            topFive++;
        }
        else
        {
            newScoreUpdate++;
            playerScores[name] = score;
            PlayerPrefs.SetString("pname_" + topFive, name);
            PlayerPrefs.SetInt("pscore_" + topFive, score);
        }
       
    }

    
}
