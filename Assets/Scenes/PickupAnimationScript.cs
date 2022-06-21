using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAnimationScript : MonoBehaviour
{
    public float turningSpeed = 50f;
    public Vector3 rotationVector = Vector3.up;

    private void FixedUpdate()
    {
        transform.Rotate(rotationVector, turningSpeed * Time.fixedDeltaTime);
    }
}
