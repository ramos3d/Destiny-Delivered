using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text milliText;

    [Header("Time in seconds")]
    public static float timeValue = 0;
    public float milliseconds;
    public static bool delivery_completed = false;
    public static bool _go = false;
    public static bool _time_over = false;

    public static bool isCarActive = true;

    private void Start() {
        delivery_completed = false;
        _go = false;
        _time_over = false;
    }
    void Update()
    {
        if(!_go) // Dont start yet.
        {
            DisplayTime(timeValue);
            return;
        }

        if(delivery_completed) 
        {
            timerText.color = Color.green;
            milliText.color = Color.green;
            DisplayTime(timeValue);
            return;
        }
        if (_time_over)
        {
            timerText.color = Color.red;
            milliText.color = Color.red;
            DisplayTime(timeValue);
            return;
        }
        if (!_time_over)
        {
            RunTimer();
        }
        
    }

    
    void RunTimer(){
        if(timeValue > 0){
            timeValue -= Time.deltaTime;   
        }else{
            timeValue = 0;
            _time_over = true;
        }
        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay){
        if(timeToDisplay < 0){
            timeToDisplay = 0;
        }
        string minutes = Mathf.FloorToInt(timeToDisplay/60).ToString("D2");
        string seconds = Mathf.FloorToInt(timeToDisplay % 60).ToString("D2");
        milliseconds = (int)((timeValue * 1000) % 1000);
        
        if(timerText != null && milliText !=null){
            timerText.text = minutes +":"+ seconds;
            milliText.text = milliseconds.ToString().Substring(1);
            
           
            if (timeToDisplay == 0){
                timerText.text = "00:00";
                milliText.text = "00";
            }
        }

    }
}
