/*---------------------------------------------
    File Name: PlayerController.cs
    Purpose: Controls the players movement
    Author: Logan Ryan
    Modified: 7 April 2021
-----------------------------------------------
    Copyright 2021 Logan Ryan
---------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
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
        animator.SetFloat("Forward", Mathf.Abs(fwd), 1f, Time.deltaTime * 10f);
        animator.SetFloat("Sense", Mathf.Sign(fwd), 1f, Time.deltaTime * 10f);
        animator.SetFloat("Turn", Input.GetAxis("Horizontal"), 1f, Time.deltaTime * 10f);
    }

    /// <summary>
    /// Do the action the player has chosen
    /// </summary>
    /// <param name="action">The player's chosen action</param>
    public void DoAction(Action action)
    {
        // If the player is not doing anything
        if (characterFX.currentAction == null)
        {
            // and has chosen to cast a fireball
            if (action.actionName == "Fireball")
            {
                // Shoot fireball
                characterFX.DoAction(actions[0]);
            }

            // or has chosen to use spirit sight
            if (action.actionName == "Spirit Sight")
            {
                // Play animation
                characterFX.DoAction(actions[1]);

                // Check if the switch has not already been activated
                foreach (GameObject go in switches)
                {
                    if (go.GetComponent<MeshRenderer>().material == activeSwitch)
                        continue;
                }

                // Change material for all "switches" to hull outline material for 5 seconds
                StartCoroutine(SpritSight());
            }
        }
        
    }

    /// <summary>
    /// Change material for all "switches" to hull outline material for 5 seconds
    /// </summary>
    /// <returns>Wait for seconds</returns>
    IEnumerator SpritSight()
    {
        Material defaultMat = switches[0].GetComponent<MeshRenderer>().material;
        
        // Check if the switches are not already activated
        foreach (GameObject go in switches)
        {
            if (go.GetComponent<MeshRenderer>().material.name == "ActiveSwitch (Instance)")
            {
                continue;
            }

            // If not then change the material to give them an oultine material
            go.GetComponent<MeshRenderer>().material = hullOutline;
        }

        // Activate greyscale post processing
        postProcessor.enabled = true;

        yield return new WaitForSeconds(5);

        // Check if the switches are not already activated
        foreach (GameObject go in switches)
        {
            if (go.GetComponent<MeshRenderer>().material.name == "ActiveSwitch (Instance)")
            {
                continue;
            }

            // If not then change the material back to its original material
            go.GetComponent<MeshRenderer>().material = defaultMat;
        }

        // Turn off the greyscale post processing
        postProcessor.enabled = false;
    }
}
