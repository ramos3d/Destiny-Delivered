using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckPoint : GameController
{
    private float seconds = 2f;
   

   
  // Confirm that the player has arrived at the drop point
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Collider>().tag == "Player")
        {
         
            if(this.GetComponent<Collider>().tag == "Checkpoint_1" && this.current_level == 1){
                GameController.new_msg = true;
                Timer._delivery_completed = true;           // stop the timer
                msg = "Well done! \n Package has been delivered on time.";
                mission_messageText.gameObject.SetActive(true);
                UI_MESSAGE.SetActive(true);
                mission_messageText.text = msg;
                StartCoroutine(WaitFor());
              
            }


            if(this.GetComponent<Collider>().tag == "Checkpoint_2" && this.current_level == 2){
                Timer._delivery_completed = true;           // stop the timer
                GameController.msg = "Well done! \n Package delivered on time. Lv. "+ this.current_level;
              
            }
        }
    }

    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(seconds);
        mission_messageText.gameObject.SetActive(false);
        UI_MESSAGE.SetActive(false);
        GameController.new_msg = false;
        yield return new WaitForSeconds(4);
        
        // Prevent mutiple calls to the same level
        if(LevelController.level_control[current_level+1] == false){
            this.NextLevel();
            LevelController.level_control[current_level+1] = true;
        }
    }
}
