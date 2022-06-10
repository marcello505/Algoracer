using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LapManager : MonoBehaviour
{
    //Public variables
    public int totalLaps = 3;
    public QuestionGateCollision[] questionGateCollisions;
    
    //Private variables
    private int currentLap = 1;
    
    //Components
    public LapUI lapUIObject;

    private void Start()
    {
        UpdateLapUI();
    }

    private void UpdateLapUI()
    {
        if(lapUIObject != null) lapUIObject.SetCurrentLaps(currentLap, totalLaps);
    }

    private void ActivateGates()
    {
        foreach (var gate in questionGateCollisions)
        {
            gate.SetQuestionActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if all gates are inactive
        var canFinishLap = questionGateCollisions.Any(g => !g.IsQuestionActive());

        if (canFinishLap)
        {
            if (currentLap >= totalLaps)
            {
                //Place finish logic here
                if(lapUIObject != null) lapUIObject.ShowFinishText();
            }
            else
            {
                //Increase lap count
                currentLap++;
            }
            UpdateLapUI();
            ActivateGates();
        }
        
    }
}
