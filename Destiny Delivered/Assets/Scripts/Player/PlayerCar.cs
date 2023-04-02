using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

// Define PlayerCar class which inherits from Cars class
public class PlayerCar : Cars
{
    // Declare serialized fields to reference virtual cameras for different perspectives
    [SerializeField] CinemachineVirtualCamera lookForwardCam;
    [SerializeField] CinemachineVirtualCamera lookBackCam;
    [SerializeField] CinemachineVirtualCamera lookRightCam;
    [SerializeField] CinemachineVirtualCamera lookLeftCam;

    // Declare serialized field to reference HealthBar
    [SerializeField] public HealthBar health_bar;

    // Declare and initialize constant for damage inflicted on player car
    private readonly float damage = 1 ;

    // Declare and initialize variable for center of mass of car to prevent flipping over
    public float new_axi = -0.9f;

    // Declare and initialize Gamepad object for input
    // Gamepad gamepad = Gamepad.current;

    // Method called when the object is enabled
    private void OnEnable() {
        // Register virtual cameras with CameraSwitch script
        CameraSwitch.Register(lookForwardCam);
        CameraSwitch.Register(lookBackCam);
        CameraSwitch.Register(lookRightCam);
        CameraSwitch.Register(lookLeftCam);
    }

    // Method called when the object is disabled
    private void OnDisable() {
        // Unregister virtual cameras with CameraSwitch script
        CameraSwitch.Unregister(lookForwardCam);
        CameraSwitch.Unregister(lookBackCam);
        CameraSwitch.Unregister(lookRightCam);
        CameraSwitch.Unregister(lookLeftCam);
    }

    // Method called when the object is started
    private void Start() {
        // Set center of mass for rigidbody to prevent flipping over
        gameObject.GetComponent<Rigidbody>().centerOfMass = new Vector3(0,new_axi, 0);
        // Set starting camera to look forward
        CameraSwitch.SwitchCamera(lookForwardCam);
    }

    // Method called every fixed update
    private void FixedUpdate() {
        // Show speedometer on UI
        ShowSpeedometer();
        // Check if right trigger on gamepad is pressed, then move car
        if (Gamepad.current != null && Gamepad.current.rightTrigger.isPressed)
        {
            Move();
        }
        // Brake the car
        Break();
    }

    // This method is called once per frame and is used to update the state of the game
    private void Update(){
        
        // Check if the Timer is running and the game is not over
        if(Timer._go == true &&  GameController.game_state == true)
        {
            // Animate the wheels of the car
            AnimateWheels();
            
            // Get the user's input
            GetInputs();
            
            // Check if the user pressed the 'R' key
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Check if the user is currently looking back, left, or forward
                if (CameraSwitch.isActiveCamera(lookBackCam) || CameraSwitch.isActiveCamera(lookLeftCam) || CameraSwitch.isActiveCamera(lookForwardCam))
                {
                    // If so, switch to the right camera
                    CameraSwitch.SwitchCamera(lookRightCam);
                }
            }
            
            // Check if the user pressed the 'Q' key
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // Check if the user is currently looking left
                if (CameraSwitch.isActiveCamera(lookLeftCam))
                {
                    // If so, switch back to the forward camera
                    CameraSwitch.SwitchCamera(lookLeftCam);
                }
                else
                {
                    // Otherwise, switch to the left camera
                    CameraSwitch.SwitchCamera(lookForwardCam);
                }
            }
            
            // Check if the user pressed the spacebar
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Check if the user is currently looking left, right, or forward
                if (CameraSwitch.isActiveCamera(lookLeftCam) || CameraSwitch.isActiveCamera(lookRightCam) || CameraSwitch.isActiveCamera(lookForwardCam))
                {
                    // If so, switch to the back camera
                    CameraSwitch.SwitchCamera(lookBackCam);
                }
            }
        }
        
        // Check if the player's health is zero or below
        if (health_bar.GetCurrentHealth() <= 0)
        {
            // If so, end the game
            GameController.game_state = false;
        }
    }

    // Detect collision and damages
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
            turnAxis = 0f;  // reset axis
            Turn();
        }
    }
}
