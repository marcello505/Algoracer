using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardUI : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
