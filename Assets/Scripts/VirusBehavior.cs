using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusBehavior : MonoBehaviour
{
    public float minDistanceToChase = 10f;
    public float maxChaseDistance = 20f;
    public float maxSpeed = 1f;
    
    //Private variables
    private Vector3 _homePos;
    private GameObject _target;

    private void Start()
    {
        _homePos = transform.position;
        _target = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        var lengthToTarget = Vector3.Distance(transform.position, _target.transform.position);

        if (lengthToTarget < minDistanceToChase)
        {
            var newPos = Vector3.MoveTowards(transform.position, _target.transform.position, maxSpeed * Time.fixedDeltaTime);
            var newPosDistanceToHome = Vector3.Distance(newPos, _homePos);
            if (newPosDistanceToHome <= maxChaseDistance)
            {
                //New position is within distance of home, thus apply
                transform.position = newPos;
            }
        }
        else
        {
            //Return or stay at home
            transform.position = Vector3.MoveTowards(transform.position, _homePos, maxSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(typeof(CarBehaviourV2), out var component))
        {
            ((CarBehaviourV2)component).Wipeout();
        }
    }
}
