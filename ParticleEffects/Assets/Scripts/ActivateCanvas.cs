/*----------------------------------------------------
    File Name: ActivateCanvas.cs
    Purpose: Activate the canvas to reveal information
    Author: Logan Ryan
    Modified: 8 April 2021
------------------------------------------------------
    Copyright 2021 Logan Ryan
----------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateCanvas : MonoBehaviour
{
    public GameObject canvas;

    public void OnTriggerEnter(Collider other)
    {
        canvas.SetActive(true);
    }
}
