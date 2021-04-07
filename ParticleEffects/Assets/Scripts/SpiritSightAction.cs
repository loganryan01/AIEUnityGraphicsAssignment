using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpiritSightAction", menuName = "VisualFX/SpiritSightAction", order = 3)]
public class SpiritSightAction : AnimatedAction
{
    public override void OnActivate(CharacterFX character)
    {
        // spawn a projctile
        //Projectile projectile = Instantiate(projectilePrefab);
        //Transform spawnPoint = character.GetBodyPart(activatePart);

        //projectile.transform.position = spawnPoint.position;
        //projectile.transform.rotation = character.transform.rotation;
        // projectile.velocity = projectile.transform.forward * projectileSpeed;
        //projectile.action = this;
        //projectileFX.Begin(projectile.transform, false);
        Debug.Log("Salute");
    }
}
