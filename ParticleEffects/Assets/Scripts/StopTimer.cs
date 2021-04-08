/*----------------------------------------------------------
    File Name: StopTimer.cs
    Purpose: Stops the timer when the player reaches the end
    Author: Logan Ryan
    Modified: 7 April 2021
------------------------------------------------------------
    Copyright 2021 Logan Ryan
----------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTimer : MonoBehaviour
{
    public TimerScript timerScript;

    private void OnTriggerEnter(Collider other)
    {
        timerScript.timerIsRunning = false;
    }
}
