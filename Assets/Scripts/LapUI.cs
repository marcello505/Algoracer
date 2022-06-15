using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LapUI : MonoBehaviour
{
    public TextMeshProUGUI lapTextObject;
    public GameObject finishScreenObject;
    public Timer timer;
    public QuestionMenu questionMenu;
    private LeaderboardManager _leaderboardManager;

    private void Start()
    {
        _leaderboardManager = GetComponent<LeaderboardManager>();
    }

    public void SetCurrentLaps(int currentLap, int totalLaps)
    {
        if(lapTextObject != null) lapTextObject.text = $"LAPS: {currentLap}/{totalLaps}";
    }

    public void ShowFinishText()
    {
        if (finishScreenObject != null) finishScreenObject.SetActive(true);
        if (_leaderboardManager != null && timer != null && questionMenu != null)
        {
            timer.StopTime();
            var leaderBoardEntry = new Leaderboard();
            leaderBoardEntry.Name = "test";
            leaderBoardEntry.Time = timer.GetTime();
            leaderBoardEntry.QuestionsRight = questionMenu.GetQuestionsAnsweredCorrectly();
            
            _leaderboardManager.connect();
            _leaderboardManager.AddToLeaderBoard(leaderBoardEntry);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
