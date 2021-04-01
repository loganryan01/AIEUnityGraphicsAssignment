using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionListUI : MonoBehaviour
{
    public ActionList actionList;
    public ActionUI prefab;

    PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = actionList.GetComponent<PlayerController>();
        
        foreach (Action a in actionList.actions)
        {
            // make this a child of ours on creation.
            // Don't worry about specifying a position as the LayoutGroup handles that
            ActionUI ui = Instantiate(prefab, transform);
            ui.SetAction(a);
            ui.Init(player);
        }
    }
}
