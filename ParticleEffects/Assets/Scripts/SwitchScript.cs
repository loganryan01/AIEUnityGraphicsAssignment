using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public Material switchMat;
    public GameObject gate;
    private bool activate;

    private void Update()
    {
        if (activate)
        {
            float dissolve = gate.GetComponent<MeshRenderer>().material.GetFloat("_DissolveAmount");

            if (dissolve > 1)
            {
                activate = false;
                Destroy(gate);
            }

            gate.GetComponent<MeshRenderer>().material.SetFloat("_DissolveAmount", dissolve + Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            gameObject.GetComponent<MeshRenderer>().material = switchMat;
            activate = true;
        }
    }
}
