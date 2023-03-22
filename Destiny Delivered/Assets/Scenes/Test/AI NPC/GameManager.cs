using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }
    private static int Level;
    private static bool newMsg;

    public static bool usingKeyBoard = true;
    private static float money;
    private static float payment;

    private static string finalTime;



    // Indicates whether the game is paused or not
    public static bool IsPaused { get; private set; }

    private void Awake()
    {
        // Create a singleton instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() {
         // Verify if there is a gamepad conected
        if (Gamepad.current != null)
        {
            SetIsUsingKeyBoard(false);
        }
    }

    // Advances to the next level of the game
    public void AdvanceLevel()
    {
        // Add code to advance to the next level of the game
    }

    // Handles the end of the game
    public static void GameOver()
    {
        GameObject windowGameOver = GameObject.Find("Panel_GameOver");
        if (windowGameOver != null){
            windowGameOver.SetActive(true);
            GameController.new_msg = false;
        } 
    }

    // Pauses the game
    public static void Pause()
    {
        Time.timeScale = 0f;
        IsPaused = true;
    }
    public static bool GetIsPaused()
    {
        return IsPaused;
    }

    public static float GetMoney(){
        return money;
    }

    public static void SetMoney(float value){
        money = value;
    }

     public static float GetPayment(){
        return payment;
    }

    public static void SetPayment(float value){
        payment = value;
    }

    // Resumes the game
    public static void Resume()
    {
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public static int GetLevel(){
        return Level;
    }
    public static void SetLevel(int lvl){
        Level = lvl;
    }

    public static void SetNewMsg(bool value){
        newMsg = value;
    }

    public static bool GetNewMsg(){
        return newMsg;
    }

    public static bool IsUsingKeyBoard(){
        return usingKeyBoard;
    }
    private static void SetIsUsingKeyBoard(bool value){
        usingKeyBoard = value;
    }
    public void RestartGame(){
        SetLevel(1);
        GameController.game_state = true;
        //UI_GAME_OVER.SetActive(false);
        //ResetAllVariables();
        SceneManager.LoadScene("LevelLoader", LoadSceneMode.Single);
    }

    public static void SetFinalTime(string time){
        finalTime = time;
    }

    public static string GetFinalTime(){
        return finalTime;
    }

    public static void HideResults(){
        GameObject windowResults = GameObject.Find("BG_Result");
        if (windowResults != null){
            windowResults.SetActive(false);

        } 
    }
}