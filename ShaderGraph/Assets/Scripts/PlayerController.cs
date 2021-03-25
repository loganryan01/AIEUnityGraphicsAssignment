﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float fwd = Input.GetAxis("Vertical");
        playerAnimator.SetFloat("Ypos", fwd);
        playerAnimator.SetFloat("Xpos", Input.GetAxis("Horizontal"));
    }
}
