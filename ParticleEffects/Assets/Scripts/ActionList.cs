/*-------------------------------------------------
    File Name: ActionList.cs
    Purpose: Get all the actions attached to object
    Author: Logan Ryan
    Modified: 7 April 2021
---------------------------------------------------
    Copyright 2021 Logan Ryan
-------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionList : MonoBehaviour
{
    Action[] _actions = null;
    public Action[] actions
    {
        get
        {
            if (_actions == null)
                _actions = GetComponents<Action>();
            return _actions;
        }
    }
}
