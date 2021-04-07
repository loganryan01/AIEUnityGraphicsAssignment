/*-------------------------------------------------
    File Name: VisualFX.cs
    Purpose: Create scriptable objects to handle FX
    Author: Logan Ryan
    Modified: 7 April 2021
---------------------------------------------------
    Copyright 2021 Logan Ryan
-------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VisualFXSystem
{
    [CreateAssetMenu(fileName = "VisualFX", menuName = "VisualFX/VisualFX", order = 1)]
    public class VisualFX : ScriptableObject
    {
        public GameObject prefab; 
        public float duration;
        public bool detach;
        public Color[] colors = new Color[] { Color.white };

        /// <summary>
        /// Create an instance of the Visual FX
        /// </summary>
        /// <param name="t">Transform of the object to parent</param>
        /// <param name="autoStop">Should the FX stop when it is finished</param>
        /// <returns>Instance of the Visual FX</returns>
        public VisualFXInstance Begin(Transform t, bool autoStop = true) 
        { 
            GameObject obj = Instantiate(prefab, detach ? null : t);

            if (detach)
                obj.transform.position = t.position;

            VisualFXInstance instance = obj.GetComponent<VisualFXInstance>(); 
            
            if (instance == null) 
                instance = obj.AddComponent<VisualFXInstance>(); instance.Init(this, autoStop); 

            return instance; 
        }
    }
}
