using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text milliText;
    public float timeValue = 30f;
    public int milliseconds;

private void Start() {
    
}
    void Update()
    {
        if(timeValue > 0){
            timeValue -= Time.deltaTime;   

        }else
        {
            timeValue = 0;
            milliseconds = 0;   
        }
        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay){
        if(timeToDisplay < 0){
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay/60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
         milliseconds = Mathf.FloorToInt(Time.deltaTime * 1000);

        timerText.text = string.Format("{0:00}:{0:30}", minutes, seconds);
        milliText.text = string.Format("{0:00}", milliseconds);
    }
}
