using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VisualFXSystem;

public abstract class AnimatedAction : ScriptableObject
{
    public string animTrigger;
    public VisualFX beginFX; 
    public CharacterFX.BodyPart beginPart; 
    public VisualFX activateFX; 
    public CharacterFX.BodyPart activatePart;

    public void Activate(CharacterFX character) 
    { 
        if (activateFX) 
            activateFX.Begin(character.GetBodyPart(activatePart)); 
        OnActivate(character); 
    }

    public abstract void OnActivate(CharacterFX character);
}
