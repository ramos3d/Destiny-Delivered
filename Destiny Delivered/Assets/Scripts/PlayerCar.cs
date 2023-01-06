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


public class PlayerCar : MonoBehaviour
{
    [SerializeField]
    private float maxAcceleration = 20.0f;
    [SerializeField]
    private float turnSensitivity = 1.0f;       // Level of sensitivity to response
    [SerializeField]
    private float maxSteerAngle = 45.0f;
    [SerializeField]
    private List<Wheel> wheels;

    //[SerializeField]
    //private Vector3 _centerOfMass;

    private float inputX, inputY;
    private Rigidbody rigid_body;

   
    private void Start()
    {
     //rigid_body = GetComponent<Rigidbody>();
     //rigid_body.centerOfMass = _centerOfMass;
     
    }


    private void Update()
    {
        AnimateWheels();
        GetInputs();

        // Respawn for Test purpose
        if(Input.GetKeyDown("space")){
            //Destroy(this);
            var _player = GameObject.FindGameObjectWithTag("Player");
            var _respawn = GameObject.FindGameObjectWithTag("Respawn");
            _player.transform.position = _respawn.transform.position;
            _player.transform.rotation = _respawn.transform.rotation;
        }
        
    }
   private void LateUpdate() {
        Move(); 
        Turn();             // To turn the wheel model
   }

   private void GetInputs()
   {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

   }

    // Move vehicle
   private void Move()
   {
        foreach (var wheel in wheels)
        {
            wheel.collider.motorTorque = inputY * maxAcceleration * 500 * Time.deltaTime;
        }
   }

    // Tur Front wheels (right-left)
   private void Turn()
   {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = inputX * turnSensitivity * maxSteerAngle;
                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, _steerAngle, 0.5f); // Interpolate betwwen two values to make it smoothier
            }
        }
   }
    
    // Animate wheel models
    private void AnimateWheels()
    {
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
