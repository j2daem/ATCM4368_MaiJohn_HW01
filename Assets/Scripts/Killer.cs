using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : Enemy
{
    protected override void PlayerImpact(Player player)
    {
        // Run base code in addition to override in derived class
        //base.PlayerImpact(player);
        player.Kill();
    }
}
