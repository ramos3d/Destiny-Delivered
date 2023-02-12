using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum Axel
{
    Front,
    Rear
}

[Serializable]
public struct Wheel
{
    public GameObject model;                    // The wheel models
    public WheelCollider collider;              // The wheel colliders
    public Axel axel;
}

public class Cars : MonoBehaviour
{
    public float maxAcceleration = 200f;
    public float turnSensitivity = 1.0f;       // Level of sensitivity to response
    public float maxSteerAngle = 35.0f;
    public List<Wheel> wheels;
    public float breaking_force = 300f;
    public float current_break_force = 0f;
    public float inputX, inputY;

 

     // Break the car
    public virtual void Break(){
        if(Input.GetKey(KeyCode.E)){
            current_break_force = breaking_force;
        }else{
            current_break_force = 0f;
        }
        foreach (var wheel in wheels)
        {
            wheel.collider.brakeTorque = current_break_force * Time.deltaTime;
        }
    }
    
    // Get generic Unity default keys
    public virtual void GetInputs(){
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
    }

   // Move the car via wheel colliders
    public virtual void Move(){
        foreach (var wheel in wheels)
        {
            //wheel.collider.motorTorque = inputY * maxAcceleration * 500 * Time.deltaTime;
            wheel.collider.motorTorque = inputY * maxAcceleration * 90000 *  Time.deltaTime ;
        }     
    }

   // Turn Front wheels to right-left
    public virtual void Turn(){
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = inputX * turnSensitivity * maxSteerAngle;
                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, _steerAngle, 0.2f); // Interpolate betwwen two values to make it smoothier
            }
        }
    }
    
    // Animate wheel models
    public void AnimateWheels(){
        foreach (var wheel in wheels)
        {
            Quaternion _rotation;    // Variable
            Vector3 _position;
            wheel.collider.GetWorldPose(out _position, out _rotation);
            wheel.model.transform.position = _position;
            wheel.model.transform.rotation = _rotation;
        }
    }
}
