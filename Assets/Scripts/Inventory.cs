using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Backing Field
    [SerializeField] int _treasureCount = 0;
    // Get/set treasure count as needed
    public int TreasureCount
    {
        get => _treasureCount;
        set => _treasureCount = value;
    }
}
