using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudio : MonoBehaviour
{
    [Range(0.0f, 3.0f)]
    public float basePitch = 0.1f;
    public float velocityModifier = 1f;
    private AudioSource _engineAudio;

    private void Start()
    {
        _engineAudio = GetComponent<AudioSource>();
    }

    public void SetPitch(float accelerationInput, float magnitude)
    {
        var pitchToAdd = Mathf.Abs(accelerationInput * magnitude * velocityModifier);
        _engineAudio.pitch = pitchToAdd + basePitch;
    }
}
