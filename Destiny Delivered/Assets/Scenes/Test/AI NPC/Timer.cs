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
    public static bool _delivery_completed = false;

    void Update()
    {
        if(_delivery_completed) {
            timerText.color = Color.green;
            milliText.color = Color.green;
            return;
        }
        RunTimer();
    }

    
    void RunTimer(){
        if(timeValue > 0){
            timeValue -= Time.deltaTime;   
        }else{
            timeValue = 0;
        }
        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay){
        if(timeToDisplay < 0){
            timeToDisplay = 0;
        }
        string minutes = Mathf.FloorToInt(timeToDisplay/60).ToString();
        string seconds = Mathf.FloorToInt(timeToDisplay % 60).ToString();
        milliseconds = (int)((timeValue * 1000) % 1000);
     
        timerText.text =  "0" + string.Format("{0:00}:{1:00}", minutes, seconds);
        milliText.text = string.Format("{0:00}", milliseconds).Substring(1);

        if (timeToDisplay == 0){
             timerText.text = "00:00";
             milliText.text = "00";
        }
    }
}
