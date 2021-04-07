/*-----------------------------
    File Name: SwitchScript.cs
    Purpose: Control the switch
    Author: Logan Ryan
    Modified: 7 April 2021
-------------------------------
    Copyright 2021 Logan Ryan
-----------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    // Material for when the switch is activated
    public Material switchMat;

    // Gate object
    public GameObject gate;
    private bool activate;

    // Update is called once per frame
    private void Update()
    {
        // If the switch is activated
        if (activate)
        {
            // Start dissolve process similar to the bush script
            
            float dissolve = gate.GetComponent<MeshRenderer>().material.GetFloat("_DissolveAmount");

            if (dissolve > 1)
            {
                activate = false;
                Destroy(gate);
            }

            gate.GetComponent<MeshRenderer>().material.SetFloat("_DissolveAmount", dissolve + Time.deltaTime);
        }
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Change materials when the switch is hit by a projectile and activate it
        if (other.gameObject.CompareTag("Projectile"))
        {
            gameObject.GetComponent<MeshRenderer>().material = switchMat;
            activate = true;
        }
    }
}
