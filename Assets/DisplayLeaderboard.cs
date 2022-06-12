using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayLeaderboard : MonoBehaviour
{
    private LeaderboardManager databaseAccess;
    private TextMeshPro leaderboardOutput;

    // Start is called before the first frame update
    void Start()
    {
        databaseAccess = GameObject.FindGameObjectWithTag("Databaseaccess").GetComponent<LeaderboardManager>();
        leaderboardOutput = GetComponentInChildren<TextMeshPro>();
        Invoke("DisplayLeaderboardInMesh", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async void DisplayLeaderboardInMesh()
    {
        var task = databaseAccess.GetLeaderboardScores();
        var result = await task;
        var output = "";

        foreach(var score in result)
        {
            output += score.Name + "Score: " + score.QuestionsRight + "\n";
        }

        Debug.Log(output);
        leaderboardOutput.text = output;
    }
}
