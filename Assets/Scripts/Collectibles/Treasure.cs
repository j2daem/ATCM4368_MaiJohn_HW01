using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : CollectibleBase
{
    // TODO: Change to event system
    [SerializeField] TreasureTrackerUI _treasureTrackerUI;

    [SerializeField] int _treasureAdded = 1;

    protected override void Collect(Player player)
    {
        Inventory inventory = player.gameObject.GetComponent<Inventory>();
        inventory.TreasureCount += _treasureAdded;

        _treasureTrackerUI.UpdateTreasureTracker(inventory.TreasureCount);
    }
}
