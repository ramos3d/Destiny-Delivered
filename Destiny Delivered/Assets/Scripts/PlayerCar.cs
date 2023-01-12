using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : Cars
{

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
