using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
  
    private int total_levels = 5;
    //Player variables based on level
    public float payment ;         // Random.Rande(15, ?)
    private string destination = null;     
    public float money;
    public TMP_Text wallet;
  
    public static bool[] level_control = new bool[]{false, false, false, false, false};
    private GameObject star;
   

    public void LoadLevel(int level_number){
        switch (level_number)
        {
            case 1:
                Timer._go = false;
                GameManager.SetNewMsg(true);
                GameController.msg = "Press ENTER when you are ready!";
                GameManager.SetMoney(100);
                GameManager.SetPayment(Random.Range(15, 50));
                destination = "1. Welcome Elonzo,\n\n- As this is your first day, drop this box at East Warehouse Base!";
                DisplayBossMessage(destination);
                wallet.text = "$" +  GameManager.GetMoney().ToString("F2");
                DisplayPaymentValue(GameManager.GetPayment().ToString("F2"));
                Debug.Log("Wallet manager:" + GameManager.GetMoney().ToString("F2") + " | payment: " + GameManager.GetMoney().ToString("F2"));
                break;
            case 2:
                star = GameObject.FindGameObjectWithTag("Star2");
                GameManager.SetPayment(Random.Range(15, 75));
                destination = "2. New Order:\n\n- Go to the West Warehouse in Downtown.";
                SetVariablesToThisLevel(level_number, destination, star);
                DisplayPaymentValue(GameManager.GetPayment().ToString("F2"));
                wallet.text = "$" + GameManager.GetMoney().ToString("F2");
            break;
            case 3:
                star = GameObject.FindGameObjectWithTag("Star2");
                star.SetActive(false);
                star = GameObject.FindGameObjectWithTag("Star3");
                GameManager.SetPayment(Random.Range(15, 90));
                destination = "3. New Order:\n\n- I need you go to the south store and get dop another pack there. Be careful this time!";
                SetVariablesToThisLevel(level_number, destination, star);
                DisplayPaymentValue(GameManager.GetPayment().ToString("F2"));
                wallet.text = "$" + GameManager.GetMoney().ToString("F2");
            break;
            case 4:
                star = GameObject.FindGameObjectWithTag("Star2");
                star.SetActive(false);
                star = GameObject.FindGameObjectWithTag("Star3");
                star.SetActive(false);
                star = GameObject.FindGameObjectWithTag("Star4");
                star.SetActive(false);
                GameManager.SetPayment(Random.Range(15, 90));
                destination = "4. New Order:\n\n- Go the the West now and drop this equipment!";
                SetVariablesToThisLevel(level_number, destination, star);
                DisplayPaymentValue(GameManager.GetPayment().ToString("F2"));
                wallet.text = "$" + GameManager.GetMoney().ToString("F2");
            break;
            case 5:
                star = GameObject.FindGameObjectWithTag("Star2");
                star.SetActive(false);
                star = GameObject.FindGameObjectWithTag("Star3");
                star.SetActive(false);
                star = GameObject.FindGameObjectWithTag("Star4");
                star.SetActive(false);
                star = GameObject.FindGameObjectWithTag("Star5");
                GameManager.SetPayment(Random.Range(15, 90));
                destination = "5. New Order:\n\n- Drive to the West Arena and drop it there ASAP!";
                SetVariablesToThisLevel(level_number, destination, star);
                DisplayPaymentValue(GameManager.GetPayment().ToString("F2"));
                wallet.text = "$" + GameManager.GetMoney().ToString("F2");
            break;
            default:
                // LOAD THE CREDITS AND GAME OVER ... THEN REDIRECT TO MENU
            break;
        }
    }

    void SetVariablesToThisLevel(int level, string destination, GameObject star){
        if (star != null){
            star.SetActive(false);
        }  
        Timer._go = false;
        GameManager.SetNewMsg(true);
        GameController.msg = "Press ENTER when you are ready! \n Level: "+GameManager.GetLevel();
        wallet.text = "$"+money.ToString("F2");
        DisplayBossMessage(destination);
    }

    void DisplayBossMessage(string message){
        TextMeshProUGUI boss_msg = GameObject.FindWithTag("Message").GetComponent<TextMeshProUGUI>();
        boss_msg.text = message;
    }
    void DisplayPaymentValue(string payment){
        TextMeshProUGUI payment_msg = GameObject.FindWithTag("Payment").GetComponent<TextMeshProUGUI>();
        payment_msg.text ="$"+ payment;
    }
     
    void CalculateProgress(){
        GameManager.SetMoney(GameManager.GetMoney() +  GameManager.GetPayment());
    }

    // Used by CheckPoints.cs
    public void NextLevel(){
        if (GameManager.GetLevel() + 1 <= total_levels){
            level_control[GameManager.GetLevel()] = true;
            GameManager.SetLevel( GameManager.GetLevel() + 1) ;
            CalculateProgress();
            SceneManager.LoadScene("LevelLoader", LoadSceneMode.Single);
            Debug.Log("Scene Reloaded");
        }else if(GameManager.GetLevel() >= total_levels){
            Debug.Log("Thanks for playing Destiny Delivered!");
        }else{
            Debug.Log("Level atual retornou >>>>>> "+ level_control[GameManager.GetLevel()] + " | na position: "+ GameManager.GetLevel());
        }
    }
}
