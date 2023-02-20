using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckPoint : GameController
{
    private float seconds = 2f;
    private bool isOn = false;

    
  // Confirm that the player has arrived at the drop point
    private void OnTriggerEnter(Collider other) {
        isOn = false;
        if (other.GetComponent<Collider>().tag == "Player")
        {
            if(this.GetComponent<Collider>().tag == "Checkpoint_1" && LevelController.current_level == 1)
            {
                this.timerText.color = Color.green;
                this.milliText.color = Color.green;
                msg = "Well done! \n Package has been delivered on time.";
                SetVariablesToThisCheckpoint(msg);
            }
            if(this.GetComponent<Collider>().tag == "Checkpoint_2" && LevelController.current_level == 2)
            {
                this.timerText.color = Color.green;
                this.milliText.color = Color.green;
                msg = "Well done! \n Package has been delivered on time.";
                SetVariablesToThisCheckpoint(msg);
            }
            if(this.GetComponent<Collider>().tag == "Checkpoint_3" && LevelController.current_level == 3)
            {
                this.timerText.color = Color.green;
                this.milliText.color = Color.green;
                msg = "Well done! \n Package has been delivered on time.";
                SetVariablesToThisCheckpoint(msg);
            }
            if(this.GetComponent<Collider>().tag == "Checkpoint_4" && LevelController.current_level == 4)
            {
                this.timerText.color = Color.green;
                this.milliText.color = Color.green;
                msg = "Well done! \n Package has been delivered on time.";
                SetVariablesToThisCheckpoint(msg);
            }
            if(this.GetComponent<Collider>().tag == "Checkpoint_5" && LevelController.current_level == 5)
            {
                this.timerText.color = Color.green;
                this.milliText.color = Color.green;
                msg = "Well done! \n Package has been delivered on time.";
                SetVariablesToThisCheckpoint(msg);
            }
        }
    }

    void SetVariablesToThisCheckpoint(string msg){
        GameController.new_msg = true;
        Timer._delivery_completed = true;           // stop the timer
        Timer._go = false;
       
        mission_messageText.gameObject.SetActive(true);
        UI_MESSAGE.SetActive(true);
        mission_messageText.text = msg;
        StartCoroutine(WaitFor());
    }

    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(seconds);
        mission_messageText.gameObject.SetActive(false);
        UI_MESSAGE.SetActive(false);
        GameController.new_msg = false;
        // Show Score
        UI_RESULTS.SetActive(true);
        this.DisplayScore();
        yield return new WaitForSeconds(4);
        // Hide Score
        UI_RESULTS.SetActive(false);

        // Prevent mutiple calls to the same level
       
        if(!isOn)
        {
            this.NextLevel();
            isOn = true;
        }
    
    }
}
