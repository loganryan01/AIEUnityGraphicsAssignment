﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 velocity; 
    Rigidbody rb = null; 
    public ProjectileAction action; 

    void Start() 
    { 
        rb = GetComponent<Rigidbody>(); 
    }
    
    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position + velocity * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // make sure that the impact effect has detach flag set or it'll disappear instantly
        if (action.impactFX && action.impactFX.detach == false)
            Debug.LogError("Impact FX "+ action.impactFX.name + " on Projectile Action"+ action.name + " has detach not set!");
        
        if(action.impactFX)
            action.impactFX.Begin(transform);

        if (other.gameObject.CompareTag("Bush"))
            other.gameObject.GetComponent<Bush>().enabled = true;

        Destroy(gameObject);
    }
}
