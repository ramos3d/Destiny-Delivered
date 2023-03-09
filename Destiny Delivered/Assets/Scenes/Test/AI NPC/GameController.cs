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

    public TMP_Text finaltime;
    public TMP_Text earned;

    public TMP_Text mission_messageText;

    public static string msg;
   
    public static bool game_state = true;

    private bool counter = true;
    private GameObject check_point;
    private string[] checkpoint_list = { "Checkpoint_1", "Checkpoint_2", "Checkpoint_3", "Checkpoint_4", "Checkpoint_5"};
    
 
    private void Start() {
       //  DontDestroyOnLoad(UI_RESULTS.gameObject);
       
        if ( GameManager.GetLevel() == 2 )
        {
            LoadLevel(GameManager.GetLevel());
          
            Debug.Log (" LOADED LV2  ->" + GameManager.GetLevel() );
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
        if ( GameManager.GetLevel() == 3 )
        {
            //isLv3 = true;
            LoadLevel(GameManager.GetLevel());
            Debug.Log (" LOADED LV3  ->" + GameManager.GetLevel());
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
        if ( GameManager.GetLevel() == 4 )
        {
            //isLv4 = true;
            LoadLevel(GameManager.GetLevel());
            Debug.Log (" LOADED LV4  ->" + GameManager.GetLevel());
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
        if ( GameManager.GetLevel() == 5 )
        {
            //isLv5 = true;
            LoadLevel(GameManager.GetLevel());
            Debug.Log (" LOADED LV5 - LAST ONE  ->" + GameManager.GetLevel());
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
    }
    void Update()
    {
         

        if(game_state) {
            
            if (Timer._go == false)
            {
               // PlayerCar.
            }
            if (Input.GetKeyDown(KeyCode.Return) && Timer._go == false)
            {
                ClearMessage();
                Timer._go = true;
            }
            
            if (Input.GetKeyDown(KeyCode.P) && Timer._go ){
                
                if (GameManager.GetIsPaused()) 
                {
                    //PauseGame();
                   // isPaused = false;
                    GameManager.Resume();
                    ClearMessage();
                }else{
                    //isPaused = true;
                    //ResumeGame();
                    ShowMessage("PAUSED!");
                    GameManager.Pause();
                }
            }
            if (GameManager.GetNewMsg())
            {
                ShowMessage(msg);
            }

            if(GameManager.GetLevel() == 1 && LevelController.level_control[GameManager.GetLevel()] == false){
                UI_GAME_OVER.SetActive(false);
                Debug.Log ("START The GAME CONTROLLER  SAYS: hey LV ->" + GameManager.GetLevel() );

                LevelController.level_control[GameManager.GetLevel()] = true;
                this.LoadLevel( GameManager.GetLevel() );

                // Make Checkpoint visible
                
                foreach (var item in checkpoint_list)
                {
                    check_point  = GameObject.FindWithTag(item);
                 
                    if (item != "Checkpoint_1" && item != null)
                    {
                        check_point.SetActive(false);
                    }
                }
            }
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
        if (mission_messageText == null) mission_messageText =  GameObject.Find("Info").GetComponent<TextMeshProUGUI>();
        
        mission_messageText.gameObject.SetActive(true);
        UI_MESSAGE.SetActive(true);
        mission_messageText.text = message;
        GameManager.SetNewMsg(false);
    }

    public void ClearMessage(){
        if (mission_messageText == null) mission_messageText =  GameObject.Find("Message").GetComponent<TextMeshProUGUI>();
        
        mission_messageText.gameObject.SetActive(false);
        UI_MESSAGE.SetActive(false);
        mission_messageText.text = "";
        GameManager.SetNewMsg(false);
    }
    public void DisplayScore(){
        if(UI_RESULTS == null){
            UI_RESULTS = GameObject.Find("BG_Result");
//            UI_RESULTS.SetActive(true);
        }else{
            UI_RESULTS.SetActive(true);
        }

        UI_RESULTS.SetActive(true);
         foreach (Transform childTransform in UI_RESULTS.transform) 
        {
            childTransform.gameObject.SetActive(true);
        }
        //GameManager.ShowResults();
        if (finaltime == null) finaltime = GameObject.Find("Final_time").GetComponent<TextMeshProUGUI>();
        if (earned == null) earned = GameObject.Find("Earned_cash").GetComponent<TextMeshProUGUI>();

        
        earned.color = Color.green;
        finaltime.text = "Time: " +  GameManager.GetFinalTime(); // T.timerText.text;
        earned.text = "$" + GameManager.GetPayment().ToString("F2");
    }


    

 
    public void RestartGame(){
        UI_GAME_OVER.SetActive(false);
        ResetAllVariables();
       // SceneManager.LoadScene("LevelLoader");
    }

    public void LoadMenu(){
       
        ResetAllVariables();
        SceneManager.LoadScene("Menu");
    }
    void GameOver(){
        GameManager.SetNewMsg(false);
        msg = "";
        //Time.timeScale = 0;
        UI_GAME_OVER.SetActive(true);
       // PauseGame ();
    }

    void ResetAllVariables(){
        Timer._delivery_completed = false;
        game_state = true;
        GameManager.SetLevel(1);
        counter = false;
        UI_GAME_OVER.SetActive(false);
        for (int i = 0; i < LevelController.level_control.Length; i++)
        {
            LevelController.level_control[i] = false;
        //    print("Levels reseted: " + LevelController.level_control[i]);
        }

       

        SceneManager.LoadScene("GameTest", LoadSceneMode.Single);
        
       // SceneManager.LoadScene("LevelLoader", LoadSceneMode.Single);

       // SceneManager.LoadSceneAsync("LevelLoader", LoadSceneMode.Single);
    }
}
