/*---------------------------------------------
    File Name: Footsteps.cs
    Purpose: Play FX when the player walks/runs
    Author: Logan Ryan
    Modified: 7 April 2021
-----------------------------------------------
    Copyright 2021 Logan Ryan
---------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VisualFXSystem;

public class Footsteps : MonoBehaviour
{
    public Transform[] feet;
    public VisualFX fx;
    
    /// <summary>
    /// Play FX every time the player steps
    /// </summary>
    /// <param name="foot">Which foot the player is on</param>
    public void Step(int foot)
    {
        // Foot has to be >0 to register in the animation event, 
        // so values of 1 and 2 correspond to
        // the first and second foot, hence the -1 here
        fx.Begin(feet[foot - 1]);
    }
}
