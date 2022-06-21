using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopwatchPickup : MonoBehaviour
{
    public float timeBonus = 2f;
    public float cooldownTime = 10f;
    private float _currentCooldown = 0f;
    private Timer _timer;
    private MeshRenderer _meshRenderer;
    public MeshRenderer _childMeshRenderer;
    private AudioSource _pickupSfx;

    void Start()
    {
        _timer = GameObject.FindObjectOfType<Timer>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _pickupSfx = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!IsOnCooldown()) ShowModel();
    }

    private void FixedUpdate()
    {
        //Decay timer
        if (IsOnCooldown())
        {
            _currentCooldown -= Time.fixedDeltaTime;
        }
    }

    private void ShowModel()
    {
        _meshRenderer.enabled = true;
        _childMeshRenderer.enabled = true;
    }

    private void HideModel()
    {
        _meshRenderer.enabled = false;
        _childMeshRenderer.enabled = false;
    }

    private bool IsOnCooldown()
    {
        return _currentCooldown > 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !IsOnCooldown())
        {
            _currentCooldown = cooldownTime;
            HideModel();
            _timer.AddTime(-timeBonus);
            _pickupSfx.Play();
        }
    }
}
