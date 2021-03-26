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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
