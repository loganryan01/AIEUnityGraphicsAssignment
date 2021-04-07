/*-----------------------------------------------
    File Name: CameraController.cs
    Purpose: Make camera follow behind the player
    Author: Logan Ryan
    Modified: 7 April 2021
-------------------------------------------------
    Copyright 2021 Logan Ryan
-----------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;

    // Distance from the player
    public float cameraDistance = 10.0f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = playerTransform.position - playerTransform.forward * cameraDistance;
        transform.LookAt(playerTransform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
    }
}
