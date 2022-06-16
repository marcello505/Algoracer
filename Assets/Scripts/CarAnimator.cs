using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimator : MonoBehaviour
{
    [Header("Wheel Settings")]
    public GameObject wheelFrontLeft;
    public GameObject wheelFrontRight;
    public GameObject wheelBackLeft;
    public GameObject wheelBackRight;

    public float maxSteeringRotation = 30f;
    public float maxWheelAcceleration = 1500f;
    public float frontWheelModifier = 0.8f;
    [Header("Animation Objects")]
    public Animation wipeoutAnimation;


    public void ApplySteering(float steeringValue)
    {
        var rotationValue = Mathf.Clamp(maxSteeringRotation * steeringValue, -maxSteeringRotation, maxSteeringRotation);
        var frontLeftRot = wheelFrontLeft.transform.localEulerAngles;
        var frontRightRot = wheelFrontRight.transform.localEulerAngles;
        frontLeftRot.y = rotationValue;
        frontRightRot.y = rotationValue;

        wheelFrontLeft.transform.localEulerAngles = frontLeftRot;
        wheelFrontRight.transform.localEulerAngles = frontRightRot;
    }

    public void ApplyAcceleration(float accelerationInput)
    {
        //Back wheels
        wheelBackLeft.transform.Rotate(Vector3.right, accelerationInput * maxWheelAcceleration * Time.fixedDeltaTime * -1);
        wheelBackRight.transform.Rotate(Vector3.right, accelerationInput * maxWheelAcceleration * Time.fixedDeltaTime * -1);
        
        //FIXME Weird bug where front wheels spaz out, feel free to take a look if you want to.
        //Front wheels
        // var frontLeftRot = wheelFrontLeft.transform.localEulerAngles;
        // var frontRightRot = wheelFrontRight.transform.localEulerAngles;
        // frontLeftRot.x += accelerationInput * maxWheelAcceleration * Time.fixedDeltaTime * frontWheelModifier;
        // frontRightRot.x += accelerationInput * maxWheelAcceleration * Time.fixedDeltaTime * frontWheelModifier;
        // wheelFrontLeft.transform.localEulerAngles = frontLeftRot;
        // wheelFrontRight.transform.localEulerAngles = frontRightRot;
    }

    public void PlayWipeoutAnimation()
    {
        wipeoutAnimation.Play();
    }
}
