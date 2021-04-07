/*------------------------------------------------------------------
    File Name: Bush.cs
    Purpose: Increase Dissolve amount over time when hit by fireball
    Author: Logan Ryan
    Modified: 7 April 2021
--------------------------------------------------------------------
    Copyright 2021 Logan Ryan
------------------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Get the dissolve value of the bush object
        float dissolve = GetComponent<MeshRenderer>().material.GetFloat("_DissolveAmount");

        // If it's greater than one destroy the object
        if (dissolve > 1)
            Destroy(gameObject);
        
        // Otherwise increase it
        GetComponent<MeshRenderer>().material.SetFloat("_DissolveAmount", dissolve + Time.deltaTime);
    }
}
