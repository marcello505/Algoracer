using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCam : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset = new Vector3(-7.5f, 7.5f, -7.5f);
    public Vector3 rotation = new Vector3(30, 45, 0);
    [Range(0.0f, 1.0f)]
    public float lerpValue = 0.5f;

    private void Start()
    {
        transform.position = target.transform.position;
        transform.rotation = Quaternion.Euler(rotation);
    }

    void FixedUpdate()
    {
        var targetPos = target.transform.position + offset;
        var currentPos = transform.position;
        transform.position = Vector3.Lerp(currentPos, targetPos, lerpValue);
        transform.rotation = Quaternion.Euler(rotation);
    }
}
