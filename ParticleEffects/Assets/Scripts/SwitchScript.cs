using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public Material switchMat;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            gameObject.GetComponent<MeshRenderer>().material = switchMat;
        }
    }
}
