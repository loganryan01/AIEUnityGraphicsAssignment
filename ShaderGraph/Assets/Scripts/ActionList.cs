using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionList : MonoBehaviour
{
    Action[] _actions = null;
    public UnityEvent onChanged;

    public Action[] actions
    {
        get
        {
            if (_actions == null)
                _actions = GetComponents<Action>();
            return _actions;
        }
    }

    [ContextMenu("Delete First")] 
    void DeleteFirst() 
    { 
        List<Action> actions = new List<Action>(_actions); 
        actions.RemoveAt(0); 
        _actions = actions.ToArray(); 
        onChanged.Invoke(); 
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
