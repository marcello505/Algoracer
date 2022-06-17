using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviourV2 : MonoBehaviour
{
    [Header("Car settings")] public float maxSpeed = 20;
    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;
    [Range(0.0f, 1.0f)]
    public float driftFactor = 0.95f;
    public float boostSpeed = 10;
    public float wipeOutLength = 5f;
    public float invulnerableLength = 5f;
    public AudioSource wipeoutAudioSource;
    
    //Local variables
    private float _rotationAngle = 0;
    private float _velocityVsForward = 0;
    private float _boostLength = 0f;
    private float _currentWipeoutLength = 0f;
    private float _currentInvulnerableLength = 0f;
    
    //Components
    private Rigidbody _rigidbody;
    private CarAnimator _carAnimator;
    private CarAudio _carAudio;
    
    private void Awake()
    {
        _rotationAngle = transform.eulerAngles.y;
        _rigidbody = GetComponent<Rigidbody>();
        _carAnimator = GetComponent<CarAnimator>();
        _carAudio = GetComponent<CarAudio>();
    }

    private void FixedUpdate()
    {
        var steeringInput = Input.GetAxis("Horizontal");
        var accelerationInput = Input.GetAxis("Vertical");
        if (QuestionMenu.isAnsweringQuestion || _currentWipeoutLength > 0)
        {
            steeringInput = 0f;
            accelerationInput = 0f;
        }
        ApplyEngineForce(accelerationInput);
        DecayTimers();
        KillOrthogonalVelocity();
        ApplySteering(steeringInput);
        ApplyAnimations(steeringInput, accelerationInput);
        ApplyAudio(accelerationInput);
    }

    void ApplyEngineForce(float accelerationInput)
    {
        //Increase maxSpeed and accelerationFactor
        var currentMaxSpeed = maxSpeed + (_boostLength > 0f ? boostSpeed : 0f);
        var currentAccelerationFactor = accelerationFactor + (_boostLength > 0f ? boostSpeed : 0f);
        
        //Calculate how much "forward" we are going in terms of the direction of our velocity
        _velocityVsForward = Vector3.Dot(transform.forward, _rigidbody.velocity);
        
        //Limit so we cannot go faster than the max speed in the forward direction
        if (_velocityVsForward > currentMaxSpeed && accelerationInput > 0)
            return;
        
        //Limit backwards speed by 50%
        if (_velocityVsForward < -currentMaxSpeed * 0.5f && accelerationInput < 0)
            return;
        
        //Limit so we cannot go faster in any direction while accelerating
        if (_rigidbody.velocity.sqrMagnitude > currentMaxSpeed * currentMaxSpeed && accelerationInput > 0)
            return;
        
        //Apply drag if no input
        if (Mathf.Approximately(accelerationInput, 0f))
            _rigidbody.drag = Mathf.Lerp(_rigidbody.drag, 3.0f, Time.fixedDeltaTime * 3);
        else _rigidbody.drag = 0;
        
        var engineForceVector = transform.forward * (currentAccelerationFactor * accelerationInput);

        System.Console.WriteLine(engineForceVector);
        _rigidbody.AddForce(engineForceVector, ForceMode.Force);
    }

    void ApplySteering(float steeringInput)
    {
        var minSpeedBeforeAllowTurningFactor = (_rigidbody.velocity.magnitude / 8);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);
        
        //When going backwards, reverse input
        var reverseInputModifier = _velocityVsForward < 0f ? -1f : 1f;
            
        _rotationAngle += steeringInput * turnFactor * minSpeedBeforeAllowTurningFactor * reverseInputModifier;

        _rigidbody.MoveRotation(Quaternion.Euler(0, _rotationAngle, 0));
    }

    void KillOrthogonalVelocity()
    {
        var forwardVelocity = transform.forward * Vector3.Dot(_rigidbody.velocity, transform.forward);
        var rightVelocity = transform.right * Vector3.Dot(_rigidbody.velocity, transform.right);

        _rigidbody.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

    void ApplyAnimations(float steeringInput, float accelerationInput)
    {
        _carAnimator.ApplySteering(steeringInput);
        _carAnimator.ApplyAcceleration(accelerationInput);
    }

    void DecayTimers()
    {
        if (_boostLength > 0) _boostLength = Mathf.Max(0, _boostLength - Time.fixedDeltaTime);
        if (_currentInvulnerableLength > 0) _currentInvulnerableLength -= Time.fixedDeltaTime;
        if (_currentWipeoutLength > 0) _currentWipeoutLength -= Time.fixedDeltaTime;
    }

    void ApplyAudio(float accelerationInput)
    {
        _carAudio.SetPitch(accelerationInput, _rigidbody.velocity.magnitude);
    }

    public void SetBoostingLength(float sec)
    {
        _boostLength = sec;
    }

    public void Wipeout()
    {
        if (_currentInvulnerableLength <= 0)
        {
            _currentInvulnerableLength = invulnerableLength;
            _currentWipeoutLength = wipeOutLength;
            _carAnimator.PlayWipeoutAnimation();
            wipeoutAudioSource.Play();
        }
    }
}
