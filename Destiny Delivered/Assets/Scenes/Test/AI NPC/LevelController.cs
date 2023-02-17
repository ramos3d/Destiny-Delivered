using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LevelController : Timer
{
    private int total_levels = 5;
    //Player variables based on level
    public float payment ;         // Random.Rande(15, ?)
    private string desdination = null;     
    private float delivered_at = 0;
    public float  money;
    public TMP_Text wallet;
    private string message_to_player = null;
    public static int current_level = 0;
    private string[] level1_msg;
    private string[] level2_msg;
    private string[] level3_msg;
    private string[] level4_msg;
    private string[] level5_msg;
    
    public GameObject startpoint_l2;
    public GameObject player_prefab;

    public static bool[] level_control = new bool[]{true, false, false, false, false};
 


    public LevelController(){
        level1_msg = new string[]{
            "Welcome Elonso, \n we have a first delivery to you. Please, take this package to the the North Warehouse.", 
            "\n Be careful with the order or the client won't pay you! \n Good luck!" 
            };
        level2_msg = new string[]{
            "Elonso, \n I have another work for you. Go to the Downtown for more details and take these orders with you. \n", 
            "Drive safe!" 
        };
    }
           

    public void StartGame(int level)
    {
        LoadLevel(level);
    }

    public string[] getGameMessages(){
        return level2_msg;
    }

    public string[] getMessageListFromLevel(int level_number){
        switch (level_number)
        {
            case 1:
                return level1_msg;
                break;
            case 2:
                return level2_msg;
                break;
            case 3:
                return level3_msg;
                break;
            case 4:
                return level4_msg;
                break;
            case 5:
                return level5_msg;
                break;
            default:
                return getGameMessages();
                break;
        }
        
    }
    public void LoadLevel(int level_number){
       Debug.Log("************ LEVEL :"+ level_number +" .........  " + Time.deltaTime);
       current_level = level_number;
        switch (level_number)
        {
            case 1:
                payment = Random.Range(15, 50);
                desdination = "Drive to Upper East Side Warehouse";
                GameController.messages_list = getMessageListFromLevel(level_number);
                GameController.new_msg = true;
                timeValue = 120;                       // Set timer for this Level
                money = 100.00f;
                wallet.text = "$ " + money.ToString("F2");
                
               
                
                break;

            case 2:
             GameObject timerText = GameObject.FindWithTag("Timer");
                GameObject milliText = GameObject.FindWithTag("Milliseconds");
              Debug.Log("************ LEVEL :"+ level_number +" .........  MOney/Payment" + money +"/"+payment);
                CalculateProgress();
                payment = Random.Range(20, 75);
                desdination = "West Warehouse in Downtown";
               
                Timer.timeValue = 60;                       // Set timer for this Level
                Timer._delivery_completed = false;
                
                wallet.text = "$"+money.ToString("F2");
                
            break;
            default:
                
            break;
        }
    }

    public void SaveMoney(){
        PlayerPrefs.SetFloat("money", money);
        PlayerPrefs.SetFloat("payment", payment);
        PlayerPrefs.Save();

    }
    public void LoadMoney(){
        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetFloat("money");
        }
        if (PlayerPrefs.HasKey("payment"))
        {
            payment = PlayerPrefs.GetFloat("payment");
        }
    }
    
    void CalculateProgress(){
        money += payment;
    }

    public void NextLevel(){
        if (current_level + 1 <= total_levels ){
            current_level++;
            // Reload scene so the GameController will call the LoadLevel()
            SaveMoney();
            SceneManager.LoadScene("LevelLoader", LoadSceneMode.Additive);
            Debug.Log("Scene Reloaded");
            
        
        }else if(current_level >= total_levels){
            Debug.Log("Thanks for playing Destiny Delivered!");
        }
       
    }

 
}
