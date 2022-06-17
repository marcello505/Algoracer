using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestionGateCollision : MonoBehaviour
{

    public GameObject questionMenu;
    [SerializeField] private UnityEvent questionGateTriggerEvent;
    private bool _questionIsActive = true;

    public bool IsQuestionActive() { return _questionIsActive; }

    public void SetQuestionActive(bool active)
    {
        _questionIsActive = active;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Player") && _questionIsActive)
        {
            _questionIsActive = false;
            questionMenu.gameObject.SetActive(true);
            questionGateTriggerEvent.Invoke();
        }

    }
}
