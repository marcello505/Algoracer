using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LapUI : MonoBehaviour
{
    public TextMeshProUGUI lapTextObject;
    public GameObject finishScreenObject;

    public void SetCurrentLaps(int currentLap, int totalLaps)
    {
        if(lapTextObject != null) lapTextObject.text = $"LAPS: {currentLap}/{totalLaps}";
    }

    public void ShowFinishText()
    {
        if (finishScreenObject != null) finishScreenObject.SetActive(true);
    }
}
