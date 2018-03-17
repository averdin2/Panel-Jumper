using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Leaderboard : MonoBehaviour {

    // Leaderboard that stores player inputed names and high scores in a dictionary

    Dictionary<string, int> playerScores;

    int newScoreUpdate = 0;

    void Start()
    {

        SetScore("Alex", 2000);
        SetScore("Catherine", 1000);
        SetScore("Daniel", 3000);
        SetScore("Joe", 5000);
        SetScore("Chris", 2000);
        SetScore("Mitch", 300);
        SetScore("Nick", 2500);
        SetScore("Joeshmoe", 10000);
        SetScore("Joeshmoe", 9999);
        //SetScore("Alex", 200000);

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

        if (playerScores.ContainsKey(playerName) == false && playerScores.Count >= 5)
        {
            string smallestScore = playerScores.Keys.OrderByDescending(name => GetScore(name)).Last();
            if(newScore > GetScore(smallestScore))
            {
                playerScores.Remove(smallestScore);
                newScoreUpdate++;
                playerScores[playerName] = newScore;
            }
            return;
        }
        else if(playerScores.ContainsKey(playerName) == true)
        {
            if(newScore > GetScore(playerName))
            {
                newScoreUpdate++;
                playerScores[playerName] = newScore;
                return;
            }
            return;
        }

        newScoreUpdate++;

        playerScores[playerName] = newScore;
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
}
