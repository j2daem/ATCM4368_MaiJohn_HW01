using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPowerUp : PowerUpBase
{
    [SerializeField] Renderer tankBody;

    Color originalColor;

    protected override void PowerUp(Player player)
    {
        //Get original color
        originalColor = tankBody.material.color;
        //Change body color
        tankBody.material.color = Color.cyan;

        //Disable damage to player
        player.Invincible = true;
    }

    protected override void PowerDown(Player player)
    {
        //Revert body color to original
        tankBody.material.color = originalColor;

        //Re-enable damage to player
        player.Invincible = false;
    }
}
