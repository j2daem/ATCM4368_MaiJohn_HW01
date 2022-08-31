using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreasureTrackerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _treasureTrackerText;

    Treasure _treasure;

    private void Awake()
    {
        _treasure = GetComponent<Treasure>();
        UpdateTreasureTracker(0);
    }

    public void UpdateTreasureTracker(int newTreasureCount)
    {
        _treasureTrackerText.text = "Treasure Count: " + newTreasureCount.ToString();
    }
}
