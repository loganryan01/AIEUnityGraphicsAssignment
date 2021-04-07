/*------------------------------------------------------
    File Name: ActionListUI.cs
    Purpose: Write the actions on the action UI template
    Author: Logan Ryan
    Modified: 7 April 2021
--------------------------------------------------------
    Copyright 2021 Logan Ryan
------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionListUI : MonoBehaviour
{
    // Object Action list
    public ActionList actionList;

    // ActionUI template
    public ActionUI prefab;

    // Player script
    PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = actionList.GetComponent<PlayerController>();
        
        foreach (Action a in actionList.actions)
        {
            // Make this a child of ours on creation.
            // Don't worry about specifying a position as the LayoutGroup handles that
            ActionUI ui = Instantiate(prefab, transform);
            ui.SetAction(a);
            ui.Init(player);
        }
    }
}
