/*-------------------------------------------------------
    File Name: Action.cs
    Purpose: Store information about an action for object
    Author: Logan Ryan
    Modified: 7 April 2021
---------------------------------------------------------
    Copyright 2021 Logan Ryan
-------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    // Name of the action
    public string actionName;

    // What does the action do
    public string description;

    // Icon of the action
    public Sprite icon;

    // Color of the icon
    public Color color = Color.white;
}
