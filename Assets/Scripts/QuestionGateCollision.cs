using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestionGateCollision : MonoBehaviour
{

    public GameObject questionMenu;
    [SerializeField] private UnityEvent questionGateTriggerEvent;
    private bool active = true;



    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Player") && active)
        {
            active = false;
            questionMenu.gameObject.SetActive(true);
            questionGateTriggerEvent.Invoke();
        }

    }
}
