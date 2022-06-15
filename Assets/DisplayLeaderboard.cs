using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayLeaderboard : MonoBehaviour
{
    private LeaderboardManager databaseAccess;
    private TextMeshProUGUI leaderboardOutput;

    // Start is called before the first frame update
    void Start()
    {
        databaseAccess = GameObject.FindGameObjectWithTag("Databaseaccess").GetComponent<LeaderboardManager>();
        leaderboardOutput = GetComponentInChildren<TextMeshProUGUI>();
        Invoke("DisplayLeaderboardInMesh", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisplayLeaderboardInMesh()
    {
        databaseAccess.connect();
        var result = databaseAccess.GetLeaderboardScores();
        var output = "";

        for (var i = 0; i < 10; i++)
        {
            if (i < result.Count)
            {
                var score = result[i];
                output += $"{i+1}.\t{score.Name}\tCorrect: {score.QuestionsRight}\tTime: {score.Time}\n";
            }
            else
            {
                output += $"{i+1}. \n";
            }
        }

        Debug.Log(output);
        leaderboardOutput.text = output;
    }
}
