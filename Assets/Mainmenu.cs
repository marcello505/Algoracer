using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{

    public GameObject startObject;
    public GameObject quitObject;
    public GameObject nameObject;
    public GameObject goObject;

    public GameObject inputField;
    public void PlayGame()
    {
        startObject.SetActive(false);
        quitObject.SetActive(false);
        nameObject.SetActive(true);
        goObject.SetActive(true);
    }

    public void startGame()
    {
        UserSettings.name = inputField.GetComponent<Text>().text;
        Debug.Log("name:" + UserSettings.name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
