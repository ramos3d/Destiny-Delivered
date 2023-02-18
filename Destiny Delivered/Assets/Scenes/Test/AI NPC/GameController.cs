using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : LevelController
{
    [SerializeField] private GameObject UI_GAME_OVER;
    [SerializeField] public GameObject UI_RESULTS;
    [Header("Config messages:")]
    [SerializeField] public GameObject UI_MESSAGE;
    public TMP_Text mission_messageText;
    public static string msg;
    public static bool new_msg = false; 
    private int level = 1;
    private bool isPaused = true;
       
    private void Start() {
        this.LoadMoney();
        if(current_level == 0){
            this.StartGame( level );
        }else{
            this.LoadLevel(current_level);
        }
    }
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)){
            if (isPaused == true)
            {
                ClearMessage();
                Timer._go = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.P) && Timer._go ){
            
            if (isPaused) 
            {
                PauseGame();
                isPaused = false;
            }else{
                isPaused = true;
                ResumeGame();
            }
        }

        if (new_msg)
        {
            ShowMessage(msg);
        }
    }

    public void ShowMessage(string message){
        mission_messageText.gameObject.SetActive(true);
        UI_MESSAGE.SetActive(true);
        mission_messageText.text = message;
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
    void PauseGame ()
    {
        ShowMessage("PAUSED");
        Time.timeScale = 0;
    }
    
    void ResumeGame ()
    {
        ClearMessage();
        Time.timeScale = 1;
    }

    void RestartGame(){
        this.LoadLevel(1);
    }
    void GameOver(){
        UI_GAME_OVER.SetActive(!UI_GAME_OVER.activeSelf);
        PauseGame ();
    }
}
