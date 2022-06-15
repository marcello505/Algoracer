using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{

    public GameObject startObject;
    public GameObject quitObject;
    public GameObject nameObject;
    public GameObject goObject;
    public void PlayGame()
    {
        startObject.SetActive(false);
        quitObject.SetActive(false);
        nameObject.SetActive(true);
        goObject.SetActive(true);
    }

    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
