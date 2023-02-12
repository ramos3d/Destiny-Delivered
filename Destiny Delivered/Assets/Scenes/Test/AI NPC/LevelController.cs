using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    //Player variables based on level
    private float _payment = 0.00f;         // Random.Rande(15, ?)
    private string _desdination = null;     
    private int _delivery_time = 0;
    private static float _wallet = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("initializing Level 1");
        
    }

    public void LoadLevel(int level_number){
        switch (level_number)
        {
            case 1:
                // Set the pickup place
                // Set the delivery location
                // Set the time to complete the delivery
                // Set the Welcome message
                // Set the first mission message
                _payment = Random.Range(15, 50);
                _desdination = "Upper East Side Warehouse";
                _delivery_time = 50;
                _wallet = 100.00f;
                print("LEVEL: " + level_number);
                print("Payment will be: " + _payment);
                print("Destination: " + _desdination);
                print("Delivery Time in seconds: " + _delivery_time);
                print("My Wallet $: " + _wallet);
                break;

            default:
                break;
        }
        

    }
    
}
