/*------------------------------------------------
    File Name: ToggleActive.cs
    Purpose: Set game object to active or unactive
    Author: Logan Ryan
    Modified: 7 April 2021
--------------------------------------------------
    Copyright 2021 Logan Ryan
------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActive : MonoBehaviour
{
    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
