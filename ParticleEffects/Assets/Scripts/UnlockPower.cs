/*----------------------------------------
    File Name: UnlockPower.cs
    Purpose: Unlock a power for the player
    Author: Logan Ryan
    Modified: 8 April 2021
------------------------------------------
    Copyright 2021 Logan Ryan
----------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockPower : MonoBehaviour
{
    // Player gameobject
    public GameObject player;

    public GameObject actionList;
    public GameObject particleEffectPrefab;

    public ActionListUI actionListUI;
    
    // Name of the action
    public string actionName;

    // What does the action do
    public string description;

    // Icon of the action
    public Sprite icon;

    // Color of the icon
    public Color color = Color.white;

    // Unlock the action for the player
    public void EnableAction()
    {
        // Add action script to player
        Action action = player.AddComponent<Action>();
        action.actionName = actionName;
        action.description = description;
        action.icon = icon;
        action.color = color;

        // Update action list
        PlayerController pc = player.GetComponent<PlayerController>();

        ActionUI ui = Instantiate(actionListUI.prefab, actionListUI.gameObject.transform);
        ui.SetAction(action);
        ui.Init(pc);

        // Turn the list back on
        var layoutGroup = actionList.transform.GetComponent<VerticalLayoutGroup>();

        layoutGroup.SetLayoutHorizontal();
        layoutGroup.SetLayoutVertical();

        LayoutRebuilder.ForceRebuildLayoutImmediate(actionList.GetComponent<RectTransform>());

        // Play particle effects
        Instantiate(particleEffectPrefab, player.transform.position, player.transform.rotation);

        Destroy(gameObject);
    }
}
