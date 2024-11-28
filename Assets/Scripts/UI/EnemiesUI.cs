using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesUI : MonoBehaviour
{
    private TextMeshProUGUI enemiesText;
    private CombatManager combatManager;

    void Start()
    {
        // Find the CombatManager to get the total number of enemies
        combatManager = GameObject.FindObjectOfType<CombatManager>();
        // Find the UI Text element to display the number of remaining enemies
        enemiesText = GameObject.Find("EnemiesText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Update enemies remaining text every frame
        enemiesText.text = "Enemies Left: " + combatManager.totalEnemies.ToString();
    }
}

