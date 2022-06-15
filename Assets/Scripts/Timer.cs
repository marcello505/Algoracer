using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    private float totalTime = 0f;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(QuestionMenu.isAnsweringQuestion == true)
        {
            return;
        }
        totalTime += Time.deltaTime;

        DisplayTime(totalTime);
    }

    public void AddTime(float timeToAdd)
    {
        totalTime += timeToAdd;
    }


    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;

        text.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

}
