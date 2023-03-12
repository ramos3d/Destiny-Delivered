using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    public static bool game_state = true;
    private bool counter = true;
    private GameObject check_point;
    private string[] checkpoint_list = {"Checkpoint_1", "Checkpoint_2", "Checkpoint_3", "Checkpoint_4", "Checkpoint_5"};
    
    private void Awake() {
        game_state = true;
    }
    private void Start() {
        switch (LevelLoader.next_level)
        {
            case 2:
                if (!isLv2)
                {
                    isLv2 = true;
                    LoadLevel(LevelLoader.next_level);
                    Debug.Log (" LOADED LV2  ->" + current_level);
                    // Make Checkpoint visible
                    foreach (var item in checkpoint_list)
                    {
                        check_point  = GameObject.FindWithTag(item);
                        if (item != "Checkpoint_2")
                        {
                            check_point.SetActive(false);
                        }
                    }
                }
                break;
                case 3:
                if ( !isLv3)
                    {
                        isLv3 = true;
                        LoadLevel(LevelLoader.next_level);
                        Debug.Log (" LOADED LV3  ->" + current_level);
                        // Make Checkpoint visible
                        foreach (var item in checkpoint_list)
                        {
                            check_point  = GameObject.FindWithTag(item);
                            if (item != "Checkpoint_3")
                            {
                                check_point.SetActive(false);
                            }
                        }
                    }
                break;
                case 4:
                if (!isLv4)
                {
                    isLv4 = true;
                    LoadLevel(LevelLoader.next_level);
                    Debug.Log (" LOADED LV4  ->" + current_level);
                    // Make Checkpoint visible
                    foreach (var item in checkpoint_list)
                    {
                        check_point  = GameObject.FindWithTag(item);
                        if (item != "Checkpoint_4")
                        {
                            check_point.SetActive(false);
                        }
                    }
                }

                break;
                case 5:
                if (!isLv5)
                {
                    isLv5 = true;
                    LoadLevel(LevelLoader.next_level);
                    Debug.Log (" LOADED LV5 - LAST ONE  ->" + current_level);
                    // Make Checkpoint visible
                    foreach (var item in checkpoint_list)
                    {
                        check_point  = GameObject.FindWithTag(item);
                        if (item != "Checkpoint_5")
                        {
                            check_point.SetActive(false);
                        }
                    }
                }
                break;
            default:
            if(current_level == 1 && LevelController.level_control[current_level] == false){
                Debug.Log ("START The GAME CONTROLLER  SAYS: hey LV ->" + current_level);
                LevelController.level_control[current_level] = true;
                this.LoadLevel( current_level );

                // Make Checkpoint visible
                foreach (var item in checkpoint_list)
                {
                    check_point  = GameObject.FindWithTag(item);
                    
                    if (item != "Checkpoint_1" && item != null && check_point != null)
                    {
                        check_point.SetActive(false);
                        
                    }
                }
            }
                break;
        }
        

    }
    void Update()
    {
        if(game_state) {
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
           
        }
        if (game_state == false)
        {
            if(counter == true){
                GameOver();
                counter = false;
                Time.timeScale = 0;
            }
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

    public void RestartGame(){
        UI_GAME_OVER.SetActive(false);
        ResetAllVariables();
        SceneManager.LoadScene("LevelLoader");
    }
    public void LoadMenu(){
        ResetAllVariables();
        SceneManager.LoadScene("Menu");
    }
    void GameOver(){
        new_msg = false;
        msg = "";
        UI_GAME_OVER.SetActive(true);
    }

    void ResetAllVariables(){
        Time.timeScale = 1;
        Timer._go = false;
        game_state = true;
        Timer._delivery_completed = false;           // stop the timer
        LevelController.current_level = current_level = 1;
        LevelLoader.next_level = current_level;
        money = 100;
        this.SaveMoney();
        for (int i = 0; i < LevelController.level_control.Length; i++)
        {
            LevelController.level_control[current_level] = false;
        }
        
        isLv2 = false;
        isLv3 = false;
        isLv4 = false;
        isLv5 = false;
        // Enable all checkpoints back
        int index = 0;
        foreach (var item in checkpoint_list)
        {
            check_point  = GameObject.FindWithTag(item);
            if (check_point != null)
            {
                index++;
                check_point.SetActive(false);
            }
        }
    }
}
