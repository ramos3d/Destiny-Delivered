using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : LevelController
{
    
    private bool restart = false;
    [SerializeField] private GameObject UI_GAME_OVER;
    [SerializeField] public GameObject UI_RESULTS;
    
    [Header("Config messages:")]
    [SerializeField] public GameObject UI_MESSAGE;
    public TMP_Text mission_messageText;
    public static string msg;
    public static string[] messages_list;
    public static bool new_msg = false; 
    //private float displayTime = 5.0f;
    private float elapsedTime = 0.0f;
    private bool activateScore = false;
    private int currentMessageIndex = 0;
    bool welcome = true;
    
    private void Start() {
        this.StartGame();
    }
   
    void Update()
    {
        if(current_level == 1 && welcome){
            mission_messageText.gameObject.SetActive(true);
            UI_MESSAGE.SetActive(true);
            mission_messageText.text = messages_list[currentMessageIndex];
            if (Input.GetKeyDown(KeyCode.Return) ){
                ClearMessage();
                welcome = false;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Return) && new_msg == true && !welcome){
            
            if (currentMessageIndex >= messages_list.Length)
            {
                currentMessageIndex = 0;
                new_msg = false;
            }
            if (new_msg)
            {
            // Show next message 
                mission_messageText.gameObject.SetActive(true);
                UI_MESSAGE.SetActive(true);
                //UI_MESSAGE.SetActive(!UI_RESULTS.activeSelf);
                mission_messageText.text = ">> " + messages_list[currentMessageIndex];
                currentMessageIndex++;
            }else{
                ClearMessage();
            }
        }
    }

    public void ShowMessage(string message){
        mission_messageText.gameObject.SetActive(true);
        UI_MESSAGE.SetActive(true);
        mission_messageText.text = message;
        elapsedTime = 0.0f;
        new_msg = false;
    }

    public void ClearMessage(){
        mission_messageText.gameObject.SetActive(false);
        UI_MESSAGE.SetActive(false);
        mission_messageText.text = "";
        new_msg = false;
    }
        void DisplayScore(){
            UI_RESULTS.SetActive(!UI_RESULTS.activeSelf);
           
        }
        

  // Confirm that the player has arrived at the drop point
  /*  private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Collider>().tag == "Player")
        {
            if(this.GetComponent<Collider>().tag == "Checkpoint_1" && this.current_level == 1){
                Debug.Log("LevelController says: YOU WIN!!!");
                Timer._delivery_completed = true;           // stop the timer
                msg = "Well done! \n Package delivered on time.";
              
                this.NextLevel();
            }

            if(this.GetComponent<Collider>().tag == "Checkpoint_2" && this.current_level == 2){
                Timer._delivery_completed = true;           // stop the timer
                msg = "Well done! \n Package delivered on time. Lv. "+ this.current_level;
                this.NextLevel();
            }
        }
    }
    */

    void PauseGame ()
    {
        Time.timeScale = 0;
    }
    
    void ResumeGame ()
    {
        Time.timeScale = 2;
    }

    void RestartGame(){
        restart = false;
        this.LoadLevel(1);
    }
    void GameOver(){
        UI_GAME_OVER.SetActive(!UI_GAME_OVER.activeSelf);
        PauseGame ();
    }

}
