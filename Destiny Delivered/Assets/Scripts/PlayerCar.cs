using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : Cars
{
    [SerializeField] HealthBar health_bar;
    private readonly float damage = 1 ;
    public float new_axi = -0.9f;
       
    private void Start() {
        gameObject.GetComponent<Rigidbody>().centerOfMass = new Vector3(0,new_axi, 0);  // Prevent car flipping over
    }

    private void FixedUpdate() {
        Break();
    }

    private void Update(){
        if(Timer._go == true)
        {
            AnimateWheels();
            GetInputs();
            // Damage test
            if(Input.GetKeyDown("space"))
            {
                PlayerDamage();
            }
        }
    }

    private void PlayerDamage(){
        float new_energy = health_bar.GetCurrentHealth() - damage;
        health_bar.SetHealth((int)new_energy);
    }

    private void LateUpdate() {
        Move(); 
        Turn();
    }
}
