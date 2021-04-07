using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    public AnimatedAction[] actions;
    public Material hullOutline;
    public Material activeSwitch;
    public PostProcessor postProcessor;
    CharacterFX characterFX;
    GameObject[] switches;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterFX = GetComponent<CharacterFX>();
        switches = GameObject.FindGameObjectsWithTag("Switch");
    }

    // Update is called once per frame
    void Update()
    {
        float fwd = Input.GetAxis("Vertical");
        animator.SetFloat("Forward", Mathf.Abs(fwd));
        animator.SetFloat("Sense", Mathf.Sign(fwd));
        animator.SetFloat("Turn", Input.GetAxis("Horizontal"));
    }

    public void DoAction(Action action)
    {
        Debug.Log("Doing " + action.actionName);
        if (characterFX.currentAction == null)
        {
            if (action.actionName == "Fireball")
            {
                // Shoot fireball
                characterFX.DoAction(actions[0]);
            }
            if (action.actionName == "Spirit Sight")
            {
                characterFX.DoAction(actions[1]);
                foreach (GameObject go in switches)
                {
                    // Change return to continue when there is more then one switch
                    if (go.GetComponent<MeshRenderer>().material == activeSwitch)
                        return;
                }

                // Change material for all "switches" to hull outline material for 10 seconds
                StartCoroutine(SpritSight());
            }
        }
        
    }

    IEnumerator SpritSight()
    {
        Material defaultMat = switches[0].GetComponent<MeshRenderer>().material;
        
        foreach (GameObject go in switches)
        {
            if (go.GetComponent<MeshRenderer>().material.name == "ActiveSwitch (Instance)")
            {
                Debug.Log("Skipped");
                continue;
            }

            Debug.Log(go.GetComponent<MeshRenderer>().material);
            go.GetComponent<MeshRenderer>().material = hullOutline;
        }

        postProcessor.enabled = true;

        yield return new WaitForSeconds(10);

        foreach (GameObject go in switches)
        {
            if (go.GetComponent<MeshRenderer>().material.name == "ActiveSwitch (Instance)")
            {
                Debug.Log("Skipped");
                continue;
            }

            Debug.Log(go.GetComponent<MeshRenderer>().material);
            go.GetComponent<MeshRenderer>().material = defaultMat;
        }

        postProcessor.enabled = false;
    }
}
