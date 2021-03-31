using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float cameraDistance = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = playerTransform.position - playerTransform.forward * cameraDistance;
        transform.LookAt(playerTransform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
    }
}
