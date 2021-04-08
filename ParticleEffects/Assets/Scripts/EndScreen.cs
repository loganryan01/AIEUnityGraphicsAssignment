/*-----------------------------------------------
    File Name: EndScreen.cs
    Purpose: Reset or end the game once completed
    Author: Logan Ryan
    Modified: 8 April 2021
-------------------------------------------------
    Copyright 2021 Logan Ryan
-----------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    // Restart the game
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    
    // Exit the game
    public void Exit()
    {
        Application.Quit();
    }
}
