using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardList : MonoBehaviour {

    // Updates the leaderboard list UI with new or updated player entries

    public GameObject leaderboardEntryPrefab;

    Leaderboard leaderboard;

    int lastScoreUpdate;

	// Use this for initialization
	void Start () {

        leaderboard = GameObject.FindObjectOfType<Leaderboard>();

        lastScoreUpdate = leaderboard.GetNewScoreUpdate();
	}
	
	// Update is called once per frame
	void Update () {
        // optimization for updating leaderboard list that checks if an update is needed as determined by Leaderboard methods
        if(leaderboard.GetNewScoreUpdate() == lastScoreUpdate)
        {
            return;
        }

        lastScoreUpdate = leaderboard.GetNewScoreUpdate();
        while(this.transform.childCount > 0)
        {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null);
            Destroy(c.gameObject);
        }

        string[] names = leaderboard.GetPlayerNames();

        foreach (string name in names)
        {
            GameObject go = (GameObject)Instantiate(leaderboardEntryPrefab);
            go.transform.SetParent(this.transform);
            go.transform.Find("PlayerName").GetComponent<Text>().text = name;
            go.transform.Find("PlayerScore").GetComponent<Text>().text = leaderboard.GetScore(name).ToString();

        }
    }
}
