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
