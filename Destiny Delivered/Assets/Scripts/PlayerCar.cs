using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody rigid_body;
   
    // Start is called before the first frame update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        carMovements();
        
    }
    /*
        Method responsible for car movements 
    */


    void carMovements(){
       try
       {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // rigid_body.velocity = Vector3.forward * speed * Time.deltaTime;
        }
       }
       catch (System.Exception ex)
       {
    
         Debug.Log("Something went wrong in the carMoments() : " + ex);
       }

    }

}
