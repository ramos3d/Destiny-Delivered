using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class PlayerCar : Cars
{
    [SerializeField] CinemachineVirtualCamera lookForwardCam;
    [SerializeField] CinemachineVirtualCamera lookBackCam;
    [SerializeField] CinemachineVirtualCamera lookRightCam;
    [SerializeField] CinemachineVirtualCamera lookLeftCam;
    
    [SerializeField] public HealthBar health_bar;
    private readonly float damage = 1 ;
    public float new_axi = -0.9f;

    // Gamepad gamepad = Gamepad.current;
           
    private void OnEnable() {
        CameraSwitch.Register(lookForwardCam);
        CameraSwitch.Register(lookBackCam);
        CameraSwitch.Register(lookRightCam);
        CameraSwitch.Register(lookLeftCam);
    }

    private void OnDisable() {
        CameraSwitch.Unregister(lookForwardCam);
        CameraSwitch.Unregister(lookBackCam);
        CameraSwitch.Unregister(lookRightCam);
        CameraSwitch.Unregister(lookLeftCam);
    }
    private void Start() {
        gameObject.GetComponent<Rigidbody>().centerOfMass = new Vector3(0,new_axi, 0);  // Prevent car flipping over
        CameraSwitch.SwitchCamera(lookForwardCam);
    }

    private void FixedUpdate() {
        ShowSpeedometer();
        if (Gamepad.current != null && Gamepad.current.rightTrigger.isPressed)
        {
            Move(); 
        }
        Break();
    }

    private void Update(){
        if(Timer._go == true &&  GameController.game_state == true)
        {
           
            AnimateWheels();
            GetInputs();

           
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (CameraSwitch.isActiveCamera(lookBackCam) || CameraSwitch.isActiveCamera(lookLeftCam) || CameraSwitch.isActiveCamera(lookForwardCam))
                {
                    CameraSwitch.SwitchCamera(lookRightCam);
                // Debug.Log("Look to Right");
                }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (CameraSwitch.isActiveCamera(lookLeftCam))
                {
                    CameraSwitch.SwitchCamera(lookLeftCam);
                }else{
                    CameraSwitch.SwitchCamera(lookForwardCam);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (CameraSwitch.isActiveCamera(lookLeftCam) || CameraSwitch.isActiveCamera(lookRightCam) || CameraSwitch.isActiveCamera(lookForwardCam))
                {
                    CameraSwitch.SwitchCamera(lookBackCam);
                    //Debug.Log("Look to Back");
                }
            }
        }
       
        if (health_bar.GetCurrentHealth() <= 0)
        {
            GameController.game_state = false;
        }
    }

    private void OnCollisionEnter(Collision other) {
        
        
            if (other.gameObject.tag != "Player" && other.gameObject.tag != "BreakLight")
            {
                PlayerDamage(); 
            }
    }
        
    public void PlayerDamage(){
        float new_energy = health_bar.GetCurrentHealth() - damage;
        health_bar.SetHealth((int)new_energy);
    }

    private void LateUpdate() {
        float turnAxis = gamepad.leftStick.x.ReadValue();   // Read the X axis of the left stick
        float newTurnAxis = gamepad.leftStick.x.ReadValue(); 
        // Verify if the stick is being moved to left or right
        if (Mathf.Abs(turnAxis) > 0.1f)                  
        {
            turnAxis = newTurnAxis;                     // Update wheels rotation
            Turn();
        }
        else
        {
            turnAxis = 0f; // reset axis
            Turn();
        }
    }
}
