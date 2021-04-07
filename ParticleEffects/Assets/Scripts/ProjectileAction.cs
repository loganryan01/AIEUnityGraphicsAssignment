/*------------------------------------
    File Name: ProjectileAction.cs
    Purpose: Control the projectile FX
    Author: Logan Ryan
    Modified: 7 April 2021
--------------------------------------
    Copyright 2021 Logan Ryan
------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VisualFXSystem;

[CreateAssetMenu(fileName = "ProjectileAction", menuName = "VisualFX/ProjectileAction", order = 2)]
public class ProjectileAction : AnimatedAction
{
    public Projectile projectilePrefab; 
    public float projectileSpeed = 10;

    public VisualFX projectileFX; 
    public VisualFX impactFX;

    public override void OnActivate(CharacterFX character)
    {
        // Spawn a projectile
        Projectile projectile = Instantiate(projectilePrefab);
        Transform spawnPoint = character.GetBodyPart(activatePart);
        
        projectile.transform.position = spawnPoint.position;
        projectile.transform.rotation = character.transform.rotation;
        projectile.velocity = projectile.transform.forward * projectileSpeed;
        projectile.action = this;
        projectileFX.Begin(projectile.transform, false);
    }
}
