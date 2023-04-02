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
    [SerializeField] private Boolean near;


  private void Start() {
    near = false;
    StartCoroutine(Example());
  }

   
  IEnumerator Example()
    {
       
        yield return new WaitForSecondsRealtime(5);
        print(Time.time);
        StartCoroutine(Example());
    }
   
   
    private void LateUpdate() {
        Turn();             // To turn the wheel model
    }

    // SELF Move the car via wheel colliders
    public override void Move(){
       //near = false;
       current_break_force = 0f;
        inputY = 0.5f;
        foreach (var wheel in wheels)
        {
            wheel.collider.motorTorque = inputY * maxAcceleration * 500 * Time.deltaTime;
        }     
    }

     // SELF Turn Front wheels to right-left
    public override void Turn(){
        foreach (var wheel in wheels)
        {
            inputX = 0f; // 1 , -1
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = inputX * turnSensitivity * maxSteerAngle;
                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, _steerAngle, 0.5f); // Interpolate betwwen two values to make it smoothier
            }
        }
    }

    public override void Break(){
         if(near == true){
            current_break_force = 50000f;
        }else{
            current_break_force = 0f;
            Move();
        }
        foreach (var wheel in wheels)
        {
            wheel.collider.brakeTorque = current_break_force * Time.deltaTime;
        }
    }
    
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position, Vector3.forward * 23.0f);

    }
}
