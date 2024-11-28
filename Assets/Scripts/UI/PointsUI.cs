using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsUI : MonoBehaviour
{
    private TextMeshProUGUI pointsText;
    private CombatManager combatManager;

    void Start()
    {
        // Find the CombatManager to get the player's points
        combatManager = GameObject.FindObjectOfType<CombatManager>();
        // Find the UI Text element to display points
        pointsText = GameObject.Find("PointsText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Update points text every frame
        pointsText.text = "Points: " + combatManager.points.ToString();
    }
}

