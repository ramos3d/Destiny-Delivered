using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSAnimator : MonoBehaviour
{
   private GameObject gps_icon;
    public float speed = 150;
    private bool move = false;
    private Vector3 limit = new Vector3(0, 1, 0);
    private Vector3 current_position;
    public float speed_animation = 2.35f;

  
    private void Start() {
        gps_icon = GameObject.FindWithTag("GPS_icon");
        current_position.y = gps_icon.transform.position.y;
        
    }
    private void FixedUpdate() {
        gps_icon.transform.Rotate(0, 0, speed * Time.deltaTime);
        Animation();
    }

    void Animation(){
         if(move){ // Down
            gps_icon.transform.position -= limit * Time.deltaTime * speed_animation;
        }else{  // Up
            gps_icon.transform.position +=  limit * Time.deltaTime * speed_animation;
        }

        if (gps_icon.transform.position.y <=current_position.y -0.5f )
        {
            move = false;
        }
        if (gps_icon.transform.position.y >= current_position.y + 0.5f )
        {
            move = true; 
        }
    }
    
    // Destroy GPS Location Icon
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Collider>().tag== "Player")
        {
           // Debug.Log(" Delete The GPS");
            Destroy(gameObject);
            
        }
    }
}
