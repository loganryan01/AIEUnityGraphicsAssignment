using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionListUI : MonoBehaviour
{
    public ActionList actionList;
    public ActionUI prefab;
    PlayerController player;
    List<ActionUI> uis = new List<ActionUI>();
    LayoutGroup layoutGroup;
    ContentSizeFitter contentSizeFitter;
    
    // Start is called before the first frame update
    void Start()
    {
        contentSizeFitter = GetComponent<ContentSizeFitter>();
        layoutGroup = GetComponent<LayoutGroup>();
        StartCoroutine(UpdateUI());

        actionList.onChanged.AddListener(() => { StartCoroutine(UpdateUI()); });
    }

    IEnumerator UpdateUI()
    {
        contentSizeFitter.enabled = true;
        layoutGroup.enabled = true;
        yield return new WaitForEndOfFrame();

        player = actionList.GetComponent<PlayerController>();

        // step through the dictionary, and remove any uis associated with actions no longer in our list
        for (int i = 0; i < actionList.actions.Length; i++)
        {
            // if we need to add another UI to our list, create it here
            if (i >= uis.Count)
            {
                // make this a child of ours on creation. 
                // Don't worry about specifying a position as the LayoutGroup handles that
                uis.Add(Instantiate(prefab, transform));
                
                // pass the player ref through and hook up any buttons
                uis[i].Init(player);
            }
            
            uis[i].gameObject.SetActive(true);
            uis[i].SetAction(actionList.actions[i]);
            
            // make sure they all appear in order again
            uis[i].transform.SetAsLastSibling();
        }
        
        // disable any remaining UIs if the list has shrunk on us
        for (int i = actionList.actions.Length; i < uis.Count; i++)
            uis[i].gameObject.SetActive(false);

        //foreach (Action a in actionList.actions)
        //{
        //    // Make this a child of ours on creation
        //    ActionUI ui = Instantiate(prefab, transform);
        //    ui.SetAction(a);
        //    ui.Init(player);
        //}

        yield return new WaitForEndOfFrame();

        contentSizeFitter.enabled = false;
        layoutGroup.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
