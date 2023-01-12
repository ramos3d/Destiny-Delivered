using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
/*
* This  class is where the PlayerCar and AICarNP classes will inherit 

*/
public class AICarNPC : Cars
{
    // Variables
    public float speed = 2;

    private void Start() {
        Move(); 
    }
    private void FixedUpdate() {
        Break();
    }
    private void Update(){
        AnimateWheels();
        GetInputs(); // Self Driving
      
    }
   
    private void LateUpdate() {
        
        Move();
        Turn();             // To turn the wheel model
    }

    // SELF Move the car via wheel colliders
    public override void Move(){
       
        foreach (var wheel in wheels)
        {
            inputY = 0.1f; // Speed
         Debug.Log("Aqui: " + inputY);
            wheel.collider.motorTorque = inputY * maxAcceleration * 500 * Time.deltaTime;
        }     
    }

     // SELF Turn Front wheels to right-left
    public override void Turn(){
        foreach (var wheel in wheels)
        {
            inputX = 1f; // 1 , -1
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = inputX * turnSensitivity * maxSteerAngle;
                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, _steerAngle, 0.5f); // Interpolate betwwen two values to make it smoothier
            }
        }
    }
}
