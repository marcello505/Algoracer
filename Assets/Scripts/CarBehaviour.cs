using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    public float turningSpeed = 50f;
    public float acceleration = 20f;
    public float reverseAcceleration = 10f;
    [Range(0.2f, 1)]
    public float accelerationCurve = 0.5f;

    public float braking = 16f;
    
    [Min(0.001f)]
    public float topSpeed = 100f;

    [Min(0.001f)]
    public float reverseSpeed = 50f;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        OldMovementBehavior();
    }

    void OldMovementBehavior()
    {
        var turningInput = Input.GetAxis("Horizontal");
        var velocityInput = Input.GetAxis("Vertical");
        
        // //transform.Rotate(new Vector3(0, 1, 0), turningInput * turningSpeed * Time.deltaTime);
        // var localVel = transform.InverseTransformVector(_rigidbody.velocity);
        // var turningPower = turningInput * turningSpeed;
        //
        // var turnAngle = Quaternion.AngleAxis(turningPower, Vector3.up);
        // var fwd = turnAngle * transform.forward;
        // var movement = fwd * velocityInput * acceleration;
        // var newVelocity = _rigidbody.velocity + movement * Time.deltaTime;
        // newVelocity.y = _rigidbody.velocity.y;
        // _rigidbody.velocity = newVelocity;
        //
        // //Turning logic
        // if (true) //TODO add check if on the ground
        // {
        //     
        //     
        //     _rigidbody.velocity = Quaternion.AngleAxis(turningPower * Mathf.Sign(localVel.z) * velocitySteering * grip * Time.deltaTime, transform.up) * _rigidbody.velocity;
        //     
        // }
        //

        transform.Rotate(Vector3.up, turningInput * turningSpeed * Time.deltaTime);
        var vel = _rigidbody.velocity;
        var additiveVel = new Vector3(0, 0, velocityInput * acceleration * Time.deltaTime);
        additiveVel = transform.rotation * additiveVel;
        vel += additiveVel;
        vel = Vector3.ClampMagnitude(vel, topSpeed);
        _rigidbody.velocity = vel;

    }

    void MoveVehicle(bool accelerate, bool brake, float turnInput)
    {
        var accelInput = (accelerate ? 1.0f : 0.0f) - (brake ? 1.0f : 0.0f);
        
        // manual acceleration curve coefficient scalar
        var accelerationCurveCoeff = 5f;
        var localVel = transform.InverseTransformVector(_rigidbody.velocity);

        var accelDirectionIsFwd = accelInput >= 0;
        var localVelDirectionIsFwd = localVel.z >= 0;
        
        // use the max speed for the direction we are going--forward or reverse.
        var maxSpeed = localVelDirectionIsFwd ? topSpeed : reverseSpeed;
        var accelPower = accelDirectionIsFwd ? acceleration : reverseSpeed;

        var currentSpeed = _rigidbody.velocity.magnitude;
        var accelRamptT = currentSpeed / maxSpeed;
        var multipliedAccelerationCurve = accelerationCurve * accelerationCurveCoeff;
        var accelRamp = Mathf.Lerp(multipliedAccelerationCurve, 1, accelRamptT * accelRamptT);
        
        bool isBraking = (localVelDirectionIsFwd && brake) || (!localVelDirectionIsFwd && accelerate);
        
        // If we are braking (moving reverse to where we are going)
        // use the braking acceleration instead
        float finalAccelPower = isBraking ? braking : accelPower;

        float finalAcceleration = finalAccelPower * accelRamp;
        
        //apply inputs to forward/backward
        float turningPower = turnInput * turningSpeed;

        var turnAngle = Quaternion.AngleAxis(turningPower, transform.up);
        var fwd = turnAngle * transform.forward;
        var collision = true;
        var movement = fwd * accelInput * finalAcceleration * ((collision) ? 1.0f : 0.0f);
        
        //Forward movement
        var wasOverMaxSpeed = currentSpeed >= maxSpeed;
        
        //if over max speed, cannot accelerate faster.
        if (wasOverMaxSpeed && !isBraking)
        {
            movement *= 0.0f;
        }

        var newVelocity = _rigidbody.velocity + movement * Time.deltaTime;
        newVelocity.y = _rigidbody.velocity.y;

        // clamp max speed if we are on ground
        // if (GroundPercent > 0.0f && !wasOverMaxSpeed)
        // {
        //     newVelocity = Vector3.ClampMagnitude(newVelocity, maxSpeed);
        // }

        _rigidbody.velocity = newVelocity;
    }
}
