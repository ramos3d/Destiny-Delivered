using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class CheckPoint: Timer
{
    private float seconds = 2f;
    private bool isOn = false;
    GameController controller  = new GameController();


  // Confirm that the player has arrived at the drop point
    private void OnTriggerEnter(Collider other) {
        isOn = false;
        if (other.GetComponent<Collider>().tag == "Player")
        {
            if(gameObject.GetComponent<Collider>().tag == "Checkpoint_1" && GameManager.GetLevel() == 1)
            {
                this.timerText.color = Color.green;
                this.milliText.color = Color.green;
                GameController.msg = "Well done! \n Package has been delivered on time.";
                SetVariablesToThisCheckpoint(GameController.msg);
            }
            if(gameObject.GetComponent<Collider>().tag == "Checkpoint_2" && GameManager.GetLevel() == 2)
            {
                this.timerText.color = Color.green;
                this.milliText.color = Color.green;
                GameController.msg = "Well done! \n Package has been delivered on time.";
                SetVariablesToThisCheckpoint(GameController.msg);
            }
            if(gameObject.GetComponent<Collider>().tag == "Checkpoint_3" && GameManager.GetLevel() == 3)
            {
                this.timerText.color = Color.green;
                this.milliText.color = Color.green;
                GameController.msg = "Well done! \n Package has been delivered on time.";
                SetVariablesToThisCheckpoint(GameController.msg);
            }
            if(gameObject.GetComponent<Collider>().tag == "Checkpoint_4" && GameManager.GetLevel() == 4)
            {
                this.timerText.color = Color.green;
                this.milliText.color = Color.green;
                GameController.msg = "Well done! \n Package has been delivered on time.";
                SetVariablesToThisCheckpoint(GameController.msg);
            }
            if(gameObject.GetComponent<Collider>().tag == "Checkpoint_5" && GameManager.GetLevel() == 5)
            {
                this.timerText.color = Color.green;
                this.milliText.color = Color.green;
                GameController.msg = "Well done! \n Package has been delivered on time.";
                SetVariablesToThisCheckpoint(GameController.msg);
            }
        }
    }

    void SetVariablesToThisCheckpoint(string msg){
        //GameController.new_msg = true;
        GameManager.SetNewMsg(true);
        Timer._delivery_completed = true;           // stop the timer
        Timer._go = false;
        if (controller.UI_MESSAGE == null)
        {
            controller.UI_MESSAGE = GameObject.Find("background_mgs");
        }else{
            controller.UI_MESSAGE.SetActive(true);
        }
        StartCoroutine(WaitFor());
    }

    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(seconds);
        controller.UI_MESSAGE.SetActive(false);
        GameManager.SetNewMsg(false);
        // Show Score
        controller.DisplayScore();
    
        yield return new WaitForSeconds(4);
        // Hide Score
        GameManager.HideResults();
        // Prevent mutiple calls to the same level
        if(!isOn)
        {
            controller.NextLevel();
            isOn = true;
        }
    }
}
