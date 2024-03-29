using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LevelController : Timer
{
    public static int total_levels = 5;
    //Player variables based on level
    public float payment ;        
    private string destination = null;     
    public float  money;
    public TMP_Text wallet;
    //public static int current_level = 1;
    public static bool[] level_control = new bool[]{false, false, false, false, false, false};
    private  GameObject star;
    //private int nextLevel;

    public void LoadLevel(int level_number){
        LoadMoney();
  
        Timer.isCarActive = true;
        switch (level_number)
        {
            case 1:
                Timer._go = false;
                GameController.new_msg = true;
                GameController.msg = "Press ENTER when you are ready!";
                timeValue = 100;                                                                                    // Set timer for this Level
                money = 100.00f;
                wallet.text = "$" + money.ToString("F2");

                payment = Random.Range(15, 50);
                destination = "1. Welcome Elonzo,\n\n- In your first day, drop this box at East Warehouse Base!";
                DisplayBossMessage(destination);
                DisplayPaymentValue(payment.ToString("F2"));
                SaveMoney();
                break;
            case 2:
                star = GameObject.FindGameObjectWithTag("Star2");
                destination = "2. New Order:\n\n- Go to the West Warehouse in Downtown.";
                SetVariablesToThisLevel(level_number, destination, star);
            break;
            case 3:
                star = GameObject.FindGameObjectWithTag("Star2");
                star.SetActive(false);
                star = GameObject.FindGameObjectWithTag("Star3");
                destination = "3. New Order:\n\n- I need you go to the south store and get dop another pack there. Be careful this time!";
                SetVariablesToThisLevel(level_number, destination, star);
            break;
            case 4:
                star = GameObject.FindGameObjectWithTag("Star2");
                star.SetActive(false);
                star = GameObject.FindGameObjectWithTag("Star3");
                star.SetActive(false);
                star = GameObject.FindGameObjectWithTag("Star4");
                star.SetActive(false);

                destination = "4. New Order:\n\n- Go the the West now and drop this equipment!";
                SetVariablesToThisLevel(level_number, destination, star);
            break;
            case 5:
                star = GameObject.FindGameObjectWithTag("Star2");
                star.SetActive(false);
                star = GameObject.FindGameObjectWithTag("Star3");
                star.SetActive(false);
                star = GameObject.FindGameObjectWithTag("Star4");
                star.SetActive(false);
                star = GameObject.FindGameObjectWithTag("Star5");
                destination = "5. New Order:\n\n- Drive to the West Arena and drop it there ASAP!";
                SetVariablesToThisLevel(level_number, destination, star);
            break;
        }
    }

    void SetVariablesToThisLevel(int level, string destination, GameObject star){
        if (star != null){
            star.SetActive(false);
        }  

        Timer._go = false;
        GameController.new_msg = true;
        GameController.msg = "Press ENTER when you are ready! \n Level: "+GameManager.GetLevel();
        CalculateProgress();
        Timer.timeValue = 60;                                                                               
        wallet.text = "$"+money.ToString("F2");
        payment = Random.Range(20, 75);
        DisplayBossMessage(destination);
        DisplayPaymentValue(payment.ToString("F2"));
        SaveMoney();
    }

    void DisplayBossMessage(string message){
        TextMeshProUGUI boss_msg = GameObject.FindWithTag("Message").GetComponent<TextMeshProUGUI>();
        boss_msg.text = message;
    }
    void DisplayPaymentValue(string payment){
        TextMeshProUGUI payment_msg = GameObject.FindWithTag("Payment").GetComponent<TextMeshProUGUI>();
        payment_msg.text ="$"+ payment;
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
        if (GameManager.GetLevel() + 1 <= total_levels){
            level_control[GameManager.GetLevel()] = true;
          
            GameManager.SetLevel(GameManager.GetLevel() + 1);
            // Reload scene so the GameController will call the LoadLevel()
            SaveMoney();
            SceneManager.LoadScene("LevelLoader", LoadSceneMode.Additive);
            Debug.Log("Scene Reloaded");
        }else if(GameManager.GetLevel() >= total_levels){
            //Debug.Log("Thanks for playing Destiny Delivered!");
           // SceneManager.LoadScene("LevelLoader", LoadSceneMode.Additive);
        }
    }
}
