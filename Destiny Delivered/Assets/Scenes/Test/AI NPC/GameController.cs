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
    private bool isPaused = true;
    public static  bool isLv2 = false;
    public static bool isLv3 = false;
    public static bool isLv4 = false;
    public static bool isLv5 = false;
    
    private void Start() {
        Debug.Log (" START GC  *** " + current_level);
            
        if ( LevelLoader.next_level == 2 && isLv2 == false)
        {
            isLv2 = true;
            LoadLevel(LevelLoader.next_level);
            Debug.Log (" LOADED LV2  ->" + current_level);
        }
        if ( LevelLoader.next_level == 3 && isLv3 == false)
        {
            isLv3 = true;
            LoadLevel(LevelLoader.next_level);
            Debug.Log (" LOADED LV3  ->" + current_level);
        }
        if ( LevelLoader.next_level == 4 && isLv4 == false)
        {
            isLv4 = true;
            LoadLevel(LevelLoader.next_level);
            Debug.Log (" LOADED LV4  ->" + current_level);
        }
        if ( LevelLoader.next_level == 5 && isLv5 == false)
        {
            isLv5 = true;
            LoadLevel(LevelLoader.next_level);
            Debug.Log (" CLOADED LV5 - LAST ONE  ->" + current_level);
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
        this.LoadMoney();
        if(current_level == 1 && LevelController.level_control[current_level] == false){
            Debug.Log ("START The GAME CONTROLLER  SAYS: hey LV ->" + current_level);
            LevelController.level_control[current_level] = true;
            this.LoadLevel( current_level );
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
    public void DisplayScore(){
        TextMeshProUGUI finaltime = GameObject.Find("Final_time").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI earned = GameObject.Find("Earned_cash").GetComponent<TextMeshProUGUI>();
        earned.color = Color.green;
        finaltime.text = "Time: " + this.timerText.text;
        earned.text = "$" + this.payment.ToString("F2");
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
