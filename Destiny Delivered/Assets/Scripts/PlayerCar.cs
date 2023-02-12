using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : Cars
{
    public float new_axi = -0.9f;
       
    private void Start() {
        // Prevent car flipping over
        gameObject.GetComponent<Rigidbody>().centerOfMass = new Vector3(0,new_axi, 0);
    }

    private void FixedUpdate() {
        Break();
    }

    private void Update(){
        AnimateWheels();
        GetInputs();

        // RESPAWN FOR TESST PURPOSE
        if(Input.GetKeyDown("space")){
            var _player = GameObject.FindGameObjectWithTag("Player");
            //var _package = GameObject.Find("Paper_Pack"); // Finding by name
            this.current_break_force = 3000000000000000f;    
            var _respawn = GameObject.FindGameObjectWithTag("Respawn");
            _player.transform.position = _respawn.transform.position;
            _player.transform.rotation = _respawn.transform.rotation;
        }
    }

    private void LateUpdate() {
        Move(); 
        Turn();             // To turn the wheel model
    }
}
