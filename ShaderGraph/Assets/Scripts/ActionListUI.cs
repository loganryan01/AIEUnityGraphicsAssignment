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
            // Make this a child of ours on creation
            ActionUI ui = Instantiate(prefab, transform);
            ui.SetAction(a);
            ui.Init(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
