/*-------------------------------------
    File Name: TimerScript.cs
    Purpose: Control timer for the game
    Author: Logan Ryan
    Modified: 7 April 2021
---------------------------------------
    Copyright 2021 Logan Ryan
-------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float startingTime = 0;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    
    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            startingTime += Time.deltaTime;
        }

        DisplayTime(startingTime);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.Floor(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
