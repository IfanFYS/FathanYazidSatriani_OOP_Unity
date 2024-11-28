using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveUI : MonoBehaviour
{
    private TextMeshProUGUI waveText;
    private CombatManager combatManager;

    void Start()
    {
        // Find the CombatManager to get the current wave number
        combatManager = GameObject.FindObjectOfType<CombatManager>();
        // Find the UI Text element to display the wave
        waveText = GameObject.Find("WaveText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Update wave number text every frame
        waveText.text = "Wave: " + combatManager.waveNumber.ToString();
    }
}
