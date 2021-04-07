/*---------------------------------
    File Name: Projectile.cs
    Purpose: Control the projectile
    Author: Logan Ryan
    Modified: 7 April 2021
-----------------------------------
    Copyright 2021 Logan Ryan
---------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 velocity; 
    Rigidbody rb = null; 
    public ProjectileAction action;

    // Start is called before the first frame update
    void Start() 
    { 
        rb = GetComponent<Rigidbody>(); 
    }
    
    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position + velocity * Time.deltaTime);
    }
    
    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Make sure that the impact effect has detach flag set or it'll disappear instantly
        if (action.impactFX && action.impactFX.detach == false)
            Debug.LogError("Impact FX "+ action.impactFX.name + " on Projectile Action"+ action.name + " has detach not set!");
        
        // Play impact FX if it has one
        if(action.impactFX)
            action.impactFX.Begin(transform);

        // Enable the bush script when the fireball collides with a bush object
        if (other.gameObject.CompareTag("Bush"))
            other.gameObject.GetComponent<Bush>().enabled = true;

        // Destroy projectile on collision
        Destroy(gameObject);
    }
}
