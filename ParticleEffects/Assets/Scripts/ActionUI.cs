/*---------------------------------------------------------------------------
    File Name: ActionUI.cs
    Purpose: Set up the action based on the information given from the player
    Author: Logan Ryan
    Modified: 7 April 2021
-----------------------------------------------------------------------------
    Copyright 2021 Logan Ryan
---------------------------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionUI : MonoBehaviour
{
    public Action action;

    [Header("Child Components")]
    public Image icon;
    public TextMeshProUGUI nameTag;
    public TextMeshProUGUI descriptionTag;

    PlayerController player;

    /// <summary>
    /// Setup button on click function
    /// </summary>
    /// <param name="p">Get player script</param>
    public void Init(PlayerController p)
    {
        // Store the player ref for use in our lambda function below
        player = p;
        // Find the button wherever we've placed it in the prefab
        // for more complicated types of prefabs with multiple buttons, we'd make this a public member
        // and hook it up in the Unity editor
        Button button = GetComponentInChildren<Button>();
        if (button)
            button.onClick.AddListener(() => { player.DoAction(action); });
    }

    /// <summary>
    /// Setup action
    /// </summary>
    /// <param name="a">An action from the player</param>
    public void SetAction(Action a)
    {
        action = a;
        if (nameTag)
            nameTag.text = action.actionName;
        if (descriptionTag)
            descriptionTag.text = action.description;
        if (icon)
        {
            icon.sprite = action.icon;
            icon.color = action.color;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        SetAction(action);
    }
}
