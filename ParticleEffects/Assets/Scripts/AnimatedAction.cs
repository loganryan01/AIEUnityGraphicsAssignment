/*-------------------------------------------------------------------
    File Name: AnimatedAction.cs
    Purpose: Trigger animation for action with VisualFX's if assigned
    Author: Logan Ryan
    Modified: 7 April 2021
---------------------------------------------------------------------
    Copyright 2021 Logan Ryan
-------------------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VisualFXSystem;

public abstract class AnimatedAction : ScriptableObject
{
    // Trigger for animation
    public string animTrigger;

    // FX to play at the beginning of the animation
    public VisualFX beginFX; 

    // What body part to play the beginning FX
    public CharacterFX.BodyPart beginPart;

    // FX to play during the animation
    public VisualFX activateFX;

    // What body part to play the activation FX
    public CharacterFX.BodyPart activatePart;

    /// <summary>
    /// Activate the activateFX
    /// </summary>
    /// <param name="character">Player FX</param>
    public void Activate(CharacterFX character) 
    { 
        if (activateFX) 
            activateFX.Begin(character.GetBodyPart(activatePart)); 
        OnActivate(character); 
    }

    /// <summary>
    /// Do extra fx for children scripts
    /// </summary>
    /// <param name="character"></param>
    public abstract void OnActivate(CharacterFX character);
}
