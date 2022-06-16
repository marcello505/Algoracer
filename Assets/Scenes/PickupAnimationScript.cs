using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAnimationScript : MonoBehaviour
{
    public float turningSpeed = 50f;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.right, turningSpeed * Time.fixedDeltaTime);
    }
}
