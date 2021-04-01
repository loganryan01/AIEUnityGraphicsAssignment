using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dissolve = GetComponent<MeshRenderer>().material.GetFloat("_DissolveAmount");

        if (dissolve > 1)
            Destroy(gameObject);

        GetComponent<MeshRenderer>().material.SetFloat("_DissolveAmount", dissolve + Time.deltaTime);
    }
}
