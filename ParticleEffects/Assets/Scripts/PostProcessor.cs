/*------------------------------------------------------
    File Name: PostProcessor.cs
    Purpose: Controls the post processing for the camera
    Author: Logan Ryan
    Modified: 7 April 2021
--------------------------------------------------------
    Copyright 2021 Logan Ryan
------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessor : MonoBehaviour
{
    // Post processing material
    public Material mat; 
    
    [ImageEffectOpaque]
    private void OnRenderImage(RenderTexture source, RenderTexture destination) 
    {
        Graphics.Blit(source, destination, mat, 0); 
    }
}
