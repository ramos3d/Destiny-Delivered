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
    private string destination = null;     
    public float  money;
    public TMP_Text wallet;
    public static int current_level = 0;
    public static bool[] level_control = new bool[]{true, false, false, false, false};
 
    public void StartGame(int level)
    {
        LoadLevel(level);
    }

    void DisplayBossMessage(string message){
        TextMeshProUGUI boss_msg = GameObject.FindWithTag("Message").GetComponent<TextMeshProUGUI>();
        boss_msg.text = message;
    }
    void DisplayPaymentValue(string payment){
            TextMeshProUGUI payment_msg = GameObject.FindWithTag("Payment").GetComponent<TextMeshProUGUI>();
            payment_msg.text ="$"+ payment;
    }
    public void LoadLevel(int level_number){
       current_level = level_number;

        switch (level_number)
        {
            case 1:
                Timer._go = false;
                GameController.new_msg = true;
                GameController.msg = "Press ENTER when you are ready!";
                timeValue = 120;                                                                                    // Set timer for this Level
                money = 100.00f;
                wallet.text = "$" + money.ToString("F2");

                payment = Random.Range(15, 50);
                destination = "Welcome Elonzo,\n\n- As your first day, drop this box at East Warehouse Base!";
                DisplayBossMessage(destination);
                DisplayPaymentValue(payment.ToString("F2"));
                break;
            case 2:
                Timer._go = false;
                GameController.new_msg = true;
                GameController.msg = "Press ENTER when you are ready!";
                CalculateProgress();
                Timer.timeValue = 60;                                                                               
                //Timer._delivery_completed = false;
                wallet.text = "$"+money.ToString("F2");

                payment = Random.Range(20, 75);
                destination = "New Order\n\n- Go to the West Warehouse\n in Downtown. \n - M : See the map";
                DisplayBossMessage(destination);
                DisplayPaymentValue(payment.ToString("F2"));
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
