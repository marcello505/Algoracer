using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{

    public GameObject startObject;
    public GameObject quitObject;
    public GameObject nameObject;
    public GameObject goObject;

    public GameObject storyObject;

    public TMP_InputField inputField;


    public void startStory()
    {
        startObject.SetActive(false);
        quitObject.SetActive(false);
        storyObject.SetActive(true);
    }

    public void PlayGame()
    {
        startObject.SetActive(false);
        quitObject.SetActive(false);
        storyObject.SetActive(false);
        nameObject.SetActive(true);
        goObject.SetActive(true);
    }

    public void startGame()
    {
        UserSettings.name = inputField.text;
        Debug.Log("name:" + UserSettings.name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
