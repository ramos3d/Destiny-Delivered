using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
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
    public float maxAcceleration = 20f;
    public float acceleration = 1f;
    public float turnSensitivity = 1.0f;       // Level of sensitivity to response
    public float maxSteerAngle = 30.0f;
    public List<Wheel> wheels;
    public float breaking_force = 30f;
    public float current_break_force = 0f;
    public float inputX, inputY;
  
    public GameObject break_light;
    private float current_speed = 0f;
    public TMP_Text speedometerText;

    [SerializeField]private Rigidbody rb;
    public Gamepad gamepad = Gamepad.current;

    private void Start() {
        break_light = GameObject.FindWithTag("BreakLight");
        break_light.SetActive(false);
        rb = GetComponent<Rigidbody>();
    }
     
    
    public virtual void Break(){
        //if(Input.GetKey(KeyCode.E) ||   gamepad.aButton.wasPressedThisFrame){
        if (Gamepad.current != null && Gamepad.current.buttonSouth.isPressed  || Timer.isCarActive == false){
           current_break_force = breaking_force;
           break_light.SetActive(true);
        }else{
            current_break_force = 0f;
            break_light.SetActive(false);
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

    public virtual void Move(){
        
        if (inputY > 0)
        {
            if (rb.velocity.magnitude < maxAcceleration)
            {
                float force = acceleration * inputY ;
                wheels[0].collider.motorTorque = inputY * maxAcceleration * 500 * force  * Time.deltaTime;
                wheels[1].collider.motorTorque = inputY * maxAcceleration * 500  * force * Time.deltaTime;
                wheels[2].collider.motorTorque = inputY * maxAcceleration * 500  * force * Time.deltaTime;
                wheels[3].collider.motorTorque = inputY * maxAcceleration * 500  * force * Time.deltaTime;
                rb.AddForce(transform.forward * force * Time.deltaTime);
            }

        }  else if (inputY < 0f)
        {
            if (rb.velocity.magnitude > - maxAcceleration / 2f)
            {
                float force = breaking_force * inputY ;
                rb.AddForce(transform.forward * force * Time.deltaTime * 3);
            }
        }
        if (current_speed <0.25)
        {
            current_speed = 0;
        }
           
    }

    public void ShowSpeedometer(){
        current_speed = rb.velocity.magnitude; 
        speedometerText.text = current_speed.ToString("F2"); 
    }
    void ControlMaxSteerAngleBasedOnVelocity(){
        
        
        if (current_speed <=2)
        {
            maxSteerAngle = 45.0f;
        }
        if (current_speed >2 && current_speed < 10)
        {
            maxSteerAngle = 30.0f;
        }else if (current_speed >= 10)
        {
            maxSteerAngle = 20.0f;
        }
        
        
    }

   // Turn Front wheels to right-left
    public virtual void Turn(){
        ControlMaxSteerAngleBasedOnVelocity();
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                float _steerAngle = inputX * turnSensitivity * maxSteerAngle;
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
