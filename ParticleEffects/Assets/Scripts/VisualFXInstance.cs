/*--------------------------------
    File Name: VisualFXInstance.cs
    Purpose: Control the VisualFX
    Author: Logan Ryan
    Modified: 7 April 2021
----------------------------------
    Copyright 2021 Logan Ryan
--------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VisualFXSystem
{
    public class VisualFXInstance: MonoBehaviour
    {
        float countdown;
        private ParticleSystem[] particles;
        public bool countingDown;

        /// <summary>
        /// Initialise the visual FX
        /// </summary>
        /// <param name="fx">The VisualFX to create an instance of</param>
        /// <param name="autoStop">Should the VisualFX stop playing on its own</param>
        public void Init(VisualFX fx, bool autoStop) 
        { 
            countingDown = autoStop; 
            countdown = fx.duration;

            int index = 0;
            particles = GetComponentsInChildren<ParticleSystem>(); 
            foreach (ParticleSystem ps in particles) 
            { 
                ParticleSystem.MainModule main = ps.main; 
                main.startColor = fx.colors[index];

                ParticleSystem.ColorOverLifetimeModule col = ps.colorOverLifetime; 
                if (col.enabled) 
                    col.color = TintGradient(col.color, fx.colors[index]);
                index++; 
                index %= fx.colors.Length;
            }
        }

        /// <summary>
        /// Change Tint Gradient of visual FX
        /// </summary>
        /// <param name="gradient"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static ParticleSystem.MinMaxGradient TintGradient(ParticleSystem.MinMaxGradient gradient, Color color) 
        { 
            switch (gradient.mode) 
            {
                case ParticleSystemGradientMode.Color : 
                    gradient.color = color; 
                    break; 
                case ParticleSystemGradientMode.Gradient :
                    { 
                        Gradient g = gradient.gradient; 
                        GradientColorKey[] colorKeys = g.colorKeys; 
                        for (int i = 0; i < colorKeys.Length; i++) 
                            colorKeys[i].color = color; 
                        g.SetKeys(colorKeys, g.alphaKeys); 
                        gradient.gradient = g; 
                    } 
                    break; 
            }

            return gradient;
        }

        // Update is called once per frame
        public void Update() 
        { 
            if (!countingDown) 
                return; 
            
            countdown -= Time.deltaTime; 
            if (countdown < 0) 
            { 
                GameObject.Destroy(gameObject); 
            } 
        }

        /// <summary>
        /// Check if its finish
        /// </summary>
        /// <returns></returns>
        public bool isFinished() 
        { 
            return countdown <= 0; 
        }

        /// <summary>
        /// Destroy game object when the FX is finished
        /// </summary>
        public void End()
        {
            Destroy(gameObject);
        }
    }
}
